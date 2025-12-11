# caffoa: Create Azure Function From Open Api

[![License](https://img.shields.io/badge/license-MIT-blue)](https://github.com/claasd/caffoa.net/blob/main/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/CdIts.Caffoa.Json.Net)](https://www.nuget.org/packages/CdIts.Caffoa.Json.Net/)
[![Nuget](https://img.shields.io/nuget/vpre/CdIts.Caffoa.Json.Net)](https://www.nuget.org/packages/CdIts.Caffoa.Json.Net/)
[![CI](https://github.com/claasd/caffoa.net/actions/workflows/build.yml/badge.svg)](https://github.com/claasd/caffoa.net/actions/workflows/build.yml)

Tool to autogenerate azure function templates for .NET from openapi declaration.
Instead of generating stubs, the goal is to be able to change the api and re-generate the files without overwriting your code.

If something does not work that you feel should work, create a ticket with your openapi spec.

* It uses [OpenAPI.NET](https://github.com/microsoft/OpenAPI.NET) for parsing the openapi spec.
* It uses a copy of version 2.0.1 of [JsonSubtypes](https://github.com/manuc66/JsonSubTypes)

# Whats new in caffoa 5.x
* Support for net 10.0 and net9.0
* Dropped support for netcore 3.1 and net7.0
* Dropped support for System.Text.Json net6.0 (allow to drop legacy support for missing feature that where introduced in net7.0)
* Renamed interface method `Json` to `Result` in `ICaffoaResultHandler`, and added accept header data. This can be used to return different content data than json.
* Drop support for `flavor: SystemTextJsonPre7` (use `flavor: SystemTextJson` instead)
* Change of default values:
    * `useIsolatedWorkerModel` now defaults to true, as this is the recommended way to use Azure Functions
    * `nullableIsDefault` not defaults to true, making non required properties `nullable` by default, even if they are not defined as nullable in the openapi definition
    * `initCollections` now defaults to true, initializing all collections, not just required ones. Be careful: collections may still be set to null if they are explicitly set to null in the payload
    * `generateEqualsMethods` now defaults to true, generating Equals and GetHashCode methods for all model classes.
    
* see [changelog](changelog.md) for all changes

# Required nuget packages

## isolated worker model (Default since V5):

You will need to install the following nuget packages:
* `Microsoft.Azure.Functions.Worker` and `Microsoft.Azure.Functions.Worker.Sdk`
* `Microsoft.Azure.Functions.Worker.Extensions.Http.AspNetCore`, this allows the use of AspNetCore objects
* `CdIts.Caffoa.Json.Net` or `CdIts.Caffoa.System.Text.Json` for caffoa interfaces and default implementations
* Optional: `Microsoft.Azure.Functions.Worker.Extensions.DurableTask` if you want to inject `[DurableClient]` into your methods


## in process model (legacy)

To use the in-process model, set the global configuration `useIsolatedWorkerModel` to `false`

You will need to install the following nuget packages:
* `Microsoft.NET.Sdk.Functions` obviously
* `Microsoft.Azure.Functions.Extensions` for function dependency injection
* `CdIts.Caffoa.Json.Net` or `CdIts.Caffoa.System.Text.Json` for caffoa interfaces and default implementations
* Optional: `Microsoft.Azure.WebJobs.Extensions.DurableTask` if you want to inject `[DurableClient]` into your methods


# Usage

As code generation needs a lot of configuration, all configuration is done using a config file in yaml format.

first, install the tool using dotnet:
```bash
dotnet new tool-manifest
dotnet tool install cdits.caffoa.cli
```

instead of installing it locally, you can install it in the global tool repo:

```bash
dotnet tool install cdits.caffoa.cli --global
```

The minimal config file is as follows (usually called `caffoa.yml`):
```yaml
services:
  - apiPath: my-service.openapi.yml
    function:
      name: MyClassName
      namespace: MyNamespace
      targetFolder: ./output
    model:
      namespace: MyNamespace.Model
      targetFolder: ./output/Model
```

You can generate a config file with default config settings using the following command:
```bash
dotnet caffoa --initwithfile my-openapi.yml --initprojectname MyFunction
```

You can add multiple services. Also, you can omit either `model` or `function` if you do not need one of them.
Then, create the c# files: 

```bash
dotnet caffoa
```

If oyu have a different yml file, or have it in a different directory, you can pass `--configfile` 
```bash
dotnet caffoa --configfile /path/to/caffoa.yml
```

## Created Azure Function template:

If you specified the `function` part in the config file, 
the tool will create two files in the specified target folder:
* `MyClassNameFunction.generated.cs`
* `IMyClassNameService.generated.cs`

Your job now is to create an implementation for the `IMyClassNameService` interface 
and implement a factory function, inheriting from `ICaffoaFactory<IMyClassNameService>`.

Example:
```c#
using Caffoa;
namespace MyNamespace {
    class MyFactory : ICaffoaFactory<IMyClassNameService>{
        IMyClassName Instance(HttpRequest request) {
            return new MyClassNameService();
        }
    }
}
```

For small APIs, you can use the same implementation class for the Implementation and the factory. 

Example:
```c#
using Caffoa;
namespace MyNamespace {
    class MyClassNameService : IMyClassNameService, ICaffoaFactory<IMyClassNameService>{
        IMyClassName Instance(HttpRequest request) {
            return new MyClassNameService();
        }
    }
    // implementation of your interface
}
```
Now implement all the logic in your implementation of the interface. You can now change your API, and regenerate the generated files without overwriting your code.

Furthermore, you need to pass your factory to the constructor of the generated function class via dependency injection.
### in process worker model:

Dependency injection works via the `FunctionsStartup` class (See [Microsoft documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection#register-services)).

Example:
```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MyNamespace {
    public class Startup : FunctionsStartup     {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddCaffoaFactory<IMyClassNameService, MyFactory>();
        }
    }
}
```
### isolated worker model:

Is the isolated worker model, dependency injection is performed [during default startup](https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide#start-up-and-configuration).

Example:
```c#
using Caffoa;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication() // <-- this is important
    .ConfigureServices(s => { 
        s.AddCaffoaFactory<IMyClassNameService, MyFactory>(); 
    })
    .Build();

await host.RunAsync();
```

## Alternative: Create ASP.NET Controller template
Since version 3.0, caffoa can also generate code for ASP.NET controller projects. Usually, this is done instead of generating function templatess.

If you specified the `controller` part in the config file, the tool will create files in the specified target folder:
* `MyClassNameController.generated.cs`
* `IMyClassNameService.generated.cs`

The concept is the same as for `functions` described in the previous section. You will need to supply your factory via APS.NET Dependency injection usually assembled `Main()`. Example:
``` csharp
using Caffoa;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(); //Add Controler and use NewtonSoft JSON
builder.Services.AddCaffoaFactory<IMyClassName, MyFactory>();
var app = builder.Build();
app.MapControllers();
await app.RunAsync();
```
To use Newtonsofts Json.NET you have to install the `Microsoft.AspNetCore.Mvc.NewtonsoftJson` Package and call `AddNewtonsoftJson()` as in the example above.
Support for System.Text.Json is still experimental in Caffoa. You can enable it with the config option `flavor: SystemTextJson` to target .NET 7/8's System.Text.Json. 

## Created data objects from schemas

If you specified the `model` part in the config file, the tool will generate a file for each schema defined in the components section of the openapi definition. The filename will be the schema name converted to UpperCamelCase with generated.cs added to the end (Example: `user`will create a class `User` defined in the file `User.generated.cs`).
The file will contain a partial class, with all properties of the schema. You can implement a partial class in a different file to add logic to these objects.

### Restrictions 
* The schema must be defined in the components section.
* Furthermore, schemas may not be nested without reference.
(You can easily overcome this restriction by defining more schemas in the components section and have them reference each other.)
* when using object inheritance (`useInheritance: true` not recomended since caffoa 2.x), allOf is implemented as inheritance, and therefore can only handle allOf with one reference and one direct configuration. When using useInheritance=false (default since caffoa 2.x), you can use multiple elements in allOf

## Advanced configuration options
There are multiple optional configuration options that you can use (shown values represent the default):

Parameters of the legacy 1.x interface can be found in the [old readme](https://github.com/claasd/caffoa.net/blob/v1.9.0/readme.md#advanced-configuration-options)

```yaml
config:
  useIsolatedWorkerModel: false # set to true to use the isolated worker model. This flag will change imports, Attributes and types
  authorizationLevel: function #  function | anonymous | system | admin
  clearGeneratedFiles: true # default is true, removes all files below the working directory, that end in .generated.cs
  duplicates: override # "once" or "override". once will not generate the same class name twice, even if it occurs in different API Specs.
  prefix: "" # A prefix that is added to all model classes
  suffix: "" # A suffix that is added to all model classes
  enumMode: Default # Default | StaticValues | StaticValuesWithoutCheck. Default creates C# enums, others modes create static values with or without check for allowed values
  routePrefix: "" # a route prefix that is added to all routes in function, e.g. 'frontend/'
  useDateOnly: true # you can set this to true if you use net6.0 and want date types to be de-serialized as DateOnly instead of DateTime.
  splitByTag: false # if set to true, multiple function files and interfaces will be generated, based on the first tag of each path item
  parsePathParameters: true # if set to false, the parameter parsing is left to Functions runtime
  parseQueryParameters: true # if set to false, query parameters will not be parsed, you have to do it yourself
  genericAdditionalProperties: false # if set to true, a dictionary for additional properties will be generated if additionalProperties is set to true or not set at all (true is default)
  genericAdditionalPropertiesType: JToken  # Default for System.Text.Json is JsonElement? different type can be used for the additionalProperties dictionary
  withCancellation: true # if set to false, caffoa will not add a CancellationToken to all interface methods. It will be triggered when the HTTP Request gets aborted (for example by the client).
  disposable: false # if set to true, Interfaces will derive from IAsyncDisposable, and functions will use `await using var instance = _factory.Instance(..);`
  useInheritance: false # When set to false, instead of inheritance, allOf will create a standalone object with converters to objects that are referenced by allOf.
  imports: [] # a list of imports that will be added to most generated classes
  requestBodyType:  # Default is NULL you can override the request body type for specific operations or methods
    type: JToken # the body type that JSON should be de-serialized to
    import: Newtonsoft.Json.Linq # optional import for the type
    filter: # filter for the operations/methods where this type should be used
      all: true # optional, uses this type for all functions
      operations: # a optional list of specific operations that should use this type
        - user-patch
      methods: # a optional list of specific methods that should use this type. All operations that use this method will use the specified type
        - patch
      prefix: patch # optinal operations where the operation id starts with this prefix. default ist null
  durableClient: # default is null. inject "[DurableClient] IDurableOrchestrationClient durableClient" into functions 
    all: true # optional, uses this type for all functions
    operations: # a optional list of specific operations that should get a durableClient
      - long-running-function
    prefix: import # add a durable client to all methods where the operation id starts with this prefix defult ist null
  functionNamePrefix: "" # adds a prefix to all function names (Not interfaces). Useful if you have multiple APIs in one function that have identical operation IDs
  extensions: true # set to false to not generate extension methods for models (UpdateWith* methods).
  asyncArrays: false # if set to true, functions that return arrays will use IAsyncEnumerable instead if Task<IEnumerable>
  constructorOnRequiredObjects: true # if set to false, no constructor will be generated for objects that have required properties, useful if oyu use external classes that do not have constructors without parameters
  useConstants: false # When set to true, values with one single enum and a matching default value will be generated as constants for strings and integer types.
  passTags: false # When set to true, The interface function will have a parameter that contains all openapi tags of that function
  removeRequiredOnReadonly: false # when set to true, required attributes will not be generated on members that are required and readOnly
  generateEqualsMethods: true # will generate Equals and GetHashCode methods for all model classes
  generateCompareOverloads: false # will generate `==` and `!=` operators for all model classes if generateEqualsMethods is set to true
  sealClassesWithEqualsMethods: true # set this to false if you do not want to seal classes tih Equals implementation for some reason
  nullableIsDefault: true # If set to true, all non-required properties with no will be treated as nullable, and the default value will be null if no default is defined. the option can be overriden either way by setting `x-caffoa-default-nullable` to true or false on an schema item.
  generateResolvedApiFile: false # will resolve all references (internal and external) and generate a single file named `originalName.generated.yml` besides the original file
  simplifyResolvedApiFile: false # will remove all schema declarations from requestBodies and responses in the generated API file. This is useful for Azure APIM, to work around the bicep file size restrictions.
  initCollections: true # if set to true, all collections will be initialized. If set to false, only required collections will be initialized
services:
  - apiPath: userservice.openapi.yml
    config: null # optional, can be any config option. That option is then overriden for this api only
    function: # Generate Azure Functions for the API
      name: MyClassName
      namespace: MyNamespace
      targetFolder: ./output
      functionsName: null # name of the functions class. defaults to {name}Functions 
      interfaceName: null # name of the interface class. defaults to I{name}Service. 
      interfaceNamespace: null # defaults to 'namespace'. If given, the interface uses this namespace
      interfaceTargetFolder: null # defaults to 'targetFolder'. If given, the interface is written to this folder
    controller: # Generate ASP.NET Controller for the API
      name: MyClassName
      namespace: MyNamespace
      targetFolder: ./output
      controllerName: null # name of the ASP.NET controller class. defaults to {name}Controller
      interfaceName: null # name of the interface class. defaults to I{name}Service. 
      interfaceNamespace: null # defaults to 'namespace'. If given, the interface uses this namespace
      interfaceTargetFolder: null # defaults to 'targetFolder'. If given, the interface is written to this folder
    model:
      namespace: MyNamespace.Model
      targetFolder: ./output/Model
      # you can exclude objects from generation:
      excludes: # default is an empty array
       - objectToExclude
      # you can also generate only some classes
      include: # default is an empty array. If includes are set, excludes are ignored
        - objectToInclude
        - otherObjectToInclude
      imports: # imports that are added in addition to the config section. Default is an empty array
        - someImport
    client: # Experimental client generation
      name: MYClientName
      namespace: MyNamespace.Client
      targetFolder: ./output/Client
      constructorVisibility: public
      fieldVisibility: public
      splitByTag: null # if set to true of false, this will override the global setting when generating clients
      IncludeTags: [] # if set, only paths with these tags will be included in the client
```

# Typed parameters and returns
Caffoa parses the return and requestBody specifications, and handles the object wrapping for you. 
* Request bodies that have well-defined schemas will be deserialized to the object
* Responses that have well-defined schemas will be serialized to Json responses
* The interface will not have IActionResult returns, but need to return the actual object for the method
* The interface will have the actual type that was passed along in the body as parameter
* Errors (400-499) will be implemented as Exceptions, that you can throw in your implementation by subclassing CaffoaClientError.
* If you have different return codes for one object (e.g. 200 or 201 for a put request), the return of the interface will be (YourObject, int).

Caffoa takes over a lot of boilerplate code for you. Furthermore, it forces you to not cut corners, as you cannot return a different object than the specification calls for.

# Dependency Injection

For simple straightforward use, you only need to pass your factory as Dependency Injection. You can, however, change the behavior of parsing, serialisation and error handling through DI.
The constructor of the generated function class takes three optional interfaces, that you can implement or inherit from the default implementation. 
Simply create an implementation of either [one of the the interfaces](https://github.com/claasd/caffoa.net/tree/main/CdIts.Caffoa.Abstractions), or inherit one of the [default implementations](https://github.com/claasd/caffoa.net/tree/main/CdIts.Caffoa/Defaults) if you only need to change a small portion.
* `ICaffoaErrorHandler` / `CaffoaDefaultErrorHandler`: handles errors that may occur during parsing. Default implementation returns BadRequest with a human readable error string
* `ICaffoaJsonParser` / `DefaultCaffoaJsonParser`: Parses incoming JSON objects to model objects.
* `ICaffoaResultHandler` / `CaffoaDefaultResultHandler`: Creates Json and result code actions from objects. Overwrite if you want to customize your JSON output.
* `ICaffoaConverter` / `DefaultCaffoaConverter`: Converts incoming string parameters to the required type, if either `parsePathParameters`or `parseQueryParameters` are set to true. 

Then, add your implementation through DI:

```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MyNamespace {
    public class Startup : FunctionsStartup     {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddCaffoaFactory<IMyClassNameService, MyFactory>();
            builder.Services.AddCaffoaResultHandler<MyResultHandler>();
        }
    }
}
```

# custom converters and annotations
the openapi doc allows for annotations. caffoa uses these annotations for custom attributes on properties and for custom json converters.

## custom converters
To use your own converter for a type, add `x-caffoa-converter: MyCustomConverter` to your openapi doc.

## Attributes
Sometimes, it is desirable to add custom attributes, for example if you want to use the generated classes for SQL.
You can use the annotation `x-caffoa-attributes` and specify a list of attributes. You can also use the shortcut x-caffoa-attribute to assign a single attribute
Example: 
```yaml
user:
  type: object
  properties:
    id:
      type: string
      x-caffoa-attribute: PrimaryKey
    someAttribute:
      type: string
      x-caffoa-attributes:
        - Computed
        - Obsolete("Do not set this attribute, it is automatically genereated")

```
this will add the annotation `[PrimaryKey]` the the `id` property.

## Removing generation of schema properties
it is possible to add a `x-caffoa-generate: false` annotation to a schema property. Then this property, as well as any copying, will not be generated.

## Delegegation implementation of properties to manually written methods
it is possible to add a `x-caffoa-delegate: true` annotation to a schema property. This will then generate partial methods to get/set this property. At least the getter must be implementeed in a shared class, the setter can be omited if the attribute is a read-only attribute.

```yaml
components:
  schemas:
    dataContainer:
      type: object
      properties:
        combinedName:
          type: string
          x-caffoa-delegate: true
```

For example, if a property 'CombinedName' has a delegate attribute, the property will be generated as follows:
```csharp
public virtual string CombinedName {
    get => GetCombinedName();
    set => SetCombinedName();
}
public partial string GetCombinedName();
partial void SetCombinedName(string value);
```

you can also set the delegate on the object instead of the property. This is useful if the property is a reference:
```yaml
components:
  schemas:
    data:
      type: string
      enum:
        - a
        - b
    dataContainer:
      type: object
      properties:
        data:
          $ref: "#/components/schemas/data"
      x-caffoa-delegates:
        - data
```

This annotation must be set at the root level of an object, it cannot be parsed through allOf/oneOf references

## Property aliases

it is possible to add a `x-caffoa-alias: otherField` annotation to a schema property. This will then generate the getter and setter for this property to get/set the property that was referenced.
Example:
```yaml
components:
  schemas:
    dataContainer:
      type: object
      properties:
        name:
          type: string
        title:
          type: string
          description: use name instead
          x-caffoa-alias: name
```

This will generate the getter and setter for `Title` to get/set name:
```csharp
[JsonProperty("title")]
public virtual string Title {
    get => Name;
    set => Name = value;
}
```

### custom alias getter/setter
instead of just an alias, you can also specify a custom getter and setter, for example to convert a legacy int field to string
```yaml
components:
  schemas:
    dataContainer:
      type: object
      properties:
        postalCode:
          type: string
        postalCodeInt:    
          type: integer
          x-caffoa-alias-get: 'int.Parse(PostalCode)'
          x-caffoa-alias-set: 'PostalCode = $"{value:D5}'
```
This will generate the getter and setter for `postalCodeInt` to get/set postalCode:
```csharp
[JsonProperty("postalCodeInt")]
public virtual string PostalCodeInt {
    get => int.Parse(PostalCode);
    set => PostalCode = $"{value:D5}";
}
```

if you do not specify x-caffoa-alias-set, an empty setter will be generated:

```yaml
components:
  schemas:
    dataContainer:
      type: object
      properties:
        street:
          type: string
        number:    
          type: string
        address:
          readonly: true
          type: string
          x-caffoa-alias-get: '$"{Street} {Number}"' 
```
will result in;
```csharp
[JsonProperty("address")]
public virtual string Address {
    get => $"{Street} {Number}";
    set {};
}
```

### specify alias at object level
you can also set the alias on the object instead of the property. This is useful if the property is a reference:
```yaml
components:
  schemas:
    data:
      type: string
      enum:
        - a
        - b
    dataContainer:
      type: object
      properties:
        data:
          $ref: "#/components/schemas/data"
        dataList:
          $ref: "#/components/schemas/data"
      x-caffoa-delegates:
        - dataList: data
```

This annotation must be set at the root level of an object, it cannot be parsed through allOf/oneOf references 


## advanced enum configuration
You can use the `x-caffoa-enum-aliases` attribute on a string enum, to define value aliases. This is useful if you have different names for the same value in different APIs, such as "asc" and "ascending".

Furthermore, you can also introduce server-only enums that point to existing enums. This is usefull if you remove an enum in favor or a new one, but backen system still use the old enum, or to do automatic mapping of backen system enums.

openapi example:
```yaml
    myEnumType:
      type: string
      enum:
        - enum1
        - enum2
        - deprecated_enum
      x-caffoa-enum-aliases:
        deprecated_enum: enum1
        deprecated_enum2: enum2

```

will generate the following code:
```csharp
namespace DemoV2.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyEnumType {
        [EnumMember(Value = "enum1")] Enum1,
        [EnumMember(Value = "enum2")] Enum2,
        [EnumMember(Value = "deprecated_enum")] Deprecated_enum = Enum1,
        [EnumMember(Value = "deprecated_enum2")] Deprecated_enum2 = Enum2
    }
}
```
You mast make sure that the enum values that are referenced are defined before the enum that references them.

# Client generation
additionally to the functions, you can generate a client that will use the same model classes for your API.
The client is generated as a partial class, so you can add your own methods to it.

```yaml
services:
  - apiPath: my-service.openapi.yml
    function:
      name: MyClassName
      namespace: MyNamespace
      targetFolder: ./output
    model:
      namespace: MyNamespace.Model
      targetFolder: ./output/Model
    client:
      name: MyClientName
      targetFolder: ./output/Client
```

See the advanced configuration options for details. 

# Changelog
The changelog is [here](changelog.md)
