# caffoa: Create Azure Function From Open Api

[![License](https://img.shields.io/pypi/l/caffoa)](https://github.com/claasd/caffoa.net/blob/main/LICENSE)
[![Nuget](https://img.shields.io/nuget/vpre/CdIts.Caffoa)](https://www.nuget.org/packages/CdIts.Caffoa/)
[![CI](https://github.com/claasd/caffoa.net/actions/workflows/build.yml/badge.svg)](https://github.com/claasd/caffoa.net/actions/workflows/build.yml)

Tool to autogenerate azure function templates for .NET from openapi declaration.
Instead of generating stubs, the goal is to be able to change the api and re-generate the files without overwriting your code.

Currently considered alpha state. If something does not work that you feel should work, create a ticket with your openapi spec.

It uses [OpenAPI.NET](https://github.com/microsoft/OpenAPI.NET) for parsing the openapi spec.

# Required nuget packages

You will need to install the following nuget packages:
* `Microsoft.NET.Sdk.Functions` obviously
* `Microsoft.Azure.Functions.Extensions` for function dependency injection
* `CdIts.Caffoa` for caffoa interfaces and default implementations

# Usage

As code generation needs a lot of configuration, all configuration is done using a config file in yaml format.

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
You can add multiple services. Also, you can omit either `model` or `function` if you do not need one of them.
Then, install and call the tool: 

```bash
dotnet new tool-manifest
dotnet tool install cdits.caffoa.cli --version 1.0.0-alpha.3
dotnet caffoa
```

instead of installing it locally, you can install it in the global tool repo:

```bash
dotnet tool install cdits.caffoa.cli --version 1.0.0-alpha.3 --global
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

For small APIs, you can use the same implementation class for the Implementation and the factory. Example:
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

Furthermore, you need [Dependency Injection](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection) to pass your factory to the constructor of the generated function class.
Example:
```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MyNamespace {
    public class Startup : FunctionsStartup     {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddSingleton<ICaffoaFactory<IMyClassNameService>, MyFactory>();
        }
    }
}
```



Now implement all the logic in your implementation of the interface. You can now change your API, and regenerate the generated files without overwriting your code.

## Created data objects from schemas

If you specified the `model` part in the config file, the tool will generate a file for each schema defined in the components section of the openapi definition. The filename will be the schema name converted to UpperCamelCase with generated.cs added to the end (Example: `user`will create a class `User` defined in the file `User.generated.cs`).
The file will contain a shared class, with all properties of the schema. You can implement a shared class in a different file to add logic to these objects.

### Restrictions 
* The schema must be defined in the components section.
* Furthermore, schemas may not be nested without reference.
(You can easily overcome this restriction by defining more schemas in the components section and have them reference each other.)
* allOf is implemented as inheritance, and therefore can only handle allOf with one reference and one direct configuration

## Advanced configuration options
There are multiple optional configuration options that you can use:
```yaml
config:
  clearGeneratedFiles: true # default is false, removes all files below the working directory, that end in .generated.cs
  duplicates: override # "once" or "override". once will not generate the same class name twice, even if it occurs in different API Specs.
  prefix: "Pre" # A prefix that is added to all model classes
  suffix: "Suf" # A suffix that is added to all model classes
  checkEnums: true # set to false to disalbe the generated checks for enums in models
  routePrefix: "api/" # a route prefix that is added to all routes in function
  useDateOnly: false # you can set this to true if you use net6.0 and want date types to be de-serialized as DateOnly instead of DateTime. 
  imports: # a list of imports that will be added to most generated classes
    - MySpecialNamespace
  requestBodyType: # you can override the request body type for specific operations or methods
    type: JObject # the body type that JSON should be de-serialized to
    import: Newtonsoft.Json.Linq # optional import for the type
    filter: # filter for the operations/methods where this type should be used 
      operations: # a list on specific operations that should use this type
        - user-patch
      methods: # list of specific methods that should use this type. All operations that use this method will use the specified type
        - patch
services:
  - apiPath: userservice.openapi.yml
    config:
      prefix:  # overrides the config element from the global config
      suffix:  # overrides the config element from the global config
      checkEnums: # overrides the config element from the global config
      routePrefix: # overrides the config element from the global config
      useDateOnly: # overrides the config element from the global config
      imports: # overrides the imports from the global config
      requestBodyType: # overrides the imports from the global config
    function:
      name: MyClassName
      namespace: MyNamespace
      targetFolder: ./output
      functionsName: MyFunctions # name of the functions class. defaults to {name}Functions 
      interfaceName: IMyInterface # name of the interface class. defaults to I{name}Service. 
      interfaceNamespace: MyInterfaceNamespace # defaults to 'namespace'. If given, the interface uses this namespace
      interfaceTargetFolder: ./output/shared # defaults to 'targetFolder'. If given, the interface is written to this folder
    model:
      namespace: MyNamespace.Model
      targetFolder: ./output/Model
      # you can exclude objects from generation:
      excludes:
       - objectToExclude
      # you can also generate only some classes
      include:
        - objectToInclude
        - otherObjectToInclude
      imports: # imports that are added in addition to the config section
        - someImport
```

# Typed parameters and returns
Caffoa parses the return and requestBody specifications, and handles the object wrapping for you. 
* Request bodies that have well-defined schemas will be deserialized to the object
* Responses that have well-defined schemas will be serialized to Json responses
* The interface will not have IActionResult returns, but need to return the actual object for the method
* The interface will have the actual type that was passed along in the body as parameter
* Errors (400-499) will be implemented as Exceptions, that you can throw in your implementation.
* If you have different return codes for one object (e.g. 200 or 201 for a put request), the return of the interface will be (YourObject, int).

Caffoa takes over a lot of boilerplate code for you. Furthermore, it forces you to not cut corners, as you cannot return a different object than the specification calls for.

# Dependency Injection

For simple straightforward use, you only need to pass your factory as Dependency Injection. You can, however, change the behavior of parsing, serialisation and error handling through DI.
The constructor of the generated function class takes three optional interfaces, that you can overwrite. 
Simply create an implementation of either [one of the the interfaces](https://github.com/claasd/caffoa.net/tree/main/CdIts.Caffoa.Abstractions), or inherit one of the [default implementations](https://github.com/claasd/caffoa.net/tree/main/CdIts.Caffoa/Defaults) if you only need to change a small portion.
* `ICaffoaErrorHandler` / `CaffoaDefaultErrorHandler`: handles errors that may occur during parsing. Default implementation returns BadRequest with a human readable error string
* `ICaffoaJsonParser` / `DefaultCaffoaJsonParser`: Parses incoming JSON objects to model objects.
* `ICaffoaResultHandler` / `CaffoaDefaultResultHandler`: Creates Json and result code actions from objects. Overwrite if you want to customize your JSON output.

Then, add your implementation through DI:

```c#
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MyNamespace {
    public class Startup : FunctionsStartup     {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddSingleton<ICaffoaFactory<IMyClassNameService>, MyFactory>();
            builder.Services.AddSingleton<ICaffoaResultHandler, MyResultHandler>();
        }
    }
}
```