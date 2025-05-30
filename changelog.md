# caffoa changelog
## 5.0.0
* Support for net9.0
* Dropped support for netcore 3.1 and net7.0
* Dropped support for System.Text.Json net6.0 (allow to drop legacy support for missing feature that where introduced in net7.0)
* Drop support for `flavor: SystemTextJsonPre7` (use `flavor: SystemTextJson` instead)
* Change of default values:
   * `useIsolatedWorkerModel` now defaults to true, as this is the recommended way to use Azure Functions
   * `nullableIsDefault` not defaults to true, making non required properties `nullable` by default, even if they are not defined as nullable in the openapi definition
   * `initCollections` now defaults to true, initializing all collections, not just required ones. Be careful: collections may still be set to null if they are explicitly set to null in the payload
   * `generateEqualsMethods` now defaults to true, generating Equals and GetHashCode methods for all model classes.
* Added `using Caffoa` to interfaces and extensions, to be able to use Caffoa extensions without having to add the Caffoa import
* Json.NET DefaultCaffoaResultHandler now serializes data itself, as dotnet isolated would ise System.Text.Json, before the inclusion of the Microsoft.AspNetCore.Mvc.NewtonsoftJson import would sowithc to Json.NET 
* Deprecated APIs will now be annotated with `[Obsolete]` attributes in Clients
* new extension in `x-caffoa-deprecate-as-error` in path will use obsolete as error in Clients

## 4.14.0
* Change of behavior in the error handler: No error will be logged if the RequestAborted cancellation token is used. This avoids logging exceptions due to the requested cancellation (e.g. RequestCancelledException or various backend cancellation exceptions). 

## 4.13.0
* experimental support for enum wrapper classes (`enumMode: Class`)
* new config value `initCollections`. If set to true, all collections will be initialized, not just required ones 

## 4.12.0
* Client generator now creates and additioanl overlaod for non-json payloads that allows to directly pass a HttpContent object
 
## 4.11.0
* allow to set a new config value `genericType` (example: `genericType : object`) that allows to define the generic type for objects where no type is specified
* new config value: `useIList` will use IList data type for lists instead of ICollection (model only)

## 4.10.4
* Fix error when overriding equals method from true to false

## 4.10.3
* Fix an issue when generating a default value for an array of enums

## 4.10.2
No release, due to a nuget issue

## 4.10.1
* fix for equals method if first array is not null but second is null

## 4.10.0
* allow to use more complex x-caffoa-alias set by using `{ setcode }` in the expression

## 4.9.1
* AnyOf parsing now removes all required properties from the object

## 4.9.0
* Fix regression from 4.8.1 that would generate wrong copy methods for object arrays
* extracted AzFuncTestHelper to a separate repository
* Add CaffoaClientStringException and CaffoaClientJsonException\<T> for easier error handling in servers
* allow to create objects with anyOf
* allow to create array objects
* handle query parameters that have characters that are not allowed in C# identifiers (e.g. types[])

## 4.8.1
* fix an error with enum lists that references enums from another yaml file

## 4.8.0
* write servers from openapi definition into client

## 4.7.1
* do not generate JsonConverter for dictionaries of dates and times

## 4.7.0
* allow to specify getter and optional setter for aliases.

## 4.6.0
* make all client methods virtual, to allow for easier mocking and overwriting

## 4.5.0
* Allow to set `x-caffoa-delegates` and `x-caffoa-aliases` on object level, to allow delegates and aliases on references
* wrong configurations of `x-caffoa-*` now raise error instead of just logging warnings

## 4.4.2
* fix regression from 4.4.0 for oneOf body models wrongly reported as unsupported complex types

## 4.4.1
* splitByTag can now be defined in the client config, to have different values for server and client
* Fix equals methods for nun-nullable Value types (Guid, DateOnly, TimeOnly, DateTimeOffset, TimeSpan)

## 4.4.0
* splitByTag now works for clients
* for clients, the tags to include can be specified
* fix a rare case where a `.DeepClone()` was appended to a dictionary of additional properties.
* default is nullable now sets add `?` at the end of value objects if `nullableIsDefault` is set to true.
* allow to specify an array of content types that should be assumed to handle Json content
* fixes to Equals methods for nullable references, arrays and maps
* Clients now use the content tyoe that was defined in the openApi instead of always using `application/json`

## 4.3.0
* new configuration option: `nullableIsDefault`. If set to true, all non-required properties with no will be treated as nullable, and the default value will be null if no default is defined. the option can be overriden either way by setting `x-caffoa-nullable` to true or false on an schema item.

## 4.2.0
* make constants that are generated for single enum elements public

## 4.1.0
* allow to selectively generate equals and comparer overlaods, by adding
  `x-caffoa-generate-equals: true|false` and `x-caffoa-generate-comparer: true|false` to the schema item. This can also be used to opt-out of global equals/comparator generation

## 4.0.1
* use Invariant() when creating client parameters in Clients
* cleanup generated openapi files
* 
## 4.0.0
* Support for NET8
* Support for isolated worker model
* Full deprecation of `CdIts.Caffoa`. There will be no new packages released. Use `CdIts.Caffoa.Json.Net` instead.
* breaking changes:
  * config option `flavor: SystemTextJson` will now use modern System.Text.Json features, and will not work with net6.0 and below. Use `flavor: SystemTextJsonPre7` for net6.0 and below.
* new config options: 
  * `generateEqualsMethods` (default `false`) will generate Equals and GetHashCode methods for all model classes. 
  The classes will be sealed by default, you can opt out of sealing those classes by setting `sealClassesWithEqualsMethods` to `false`. If you use `useInheritance`, the classes will also not be sealed.
  
  
  * `generateCompareOverloads` (default `false`) will generate `==` and `!=` operators for all model classes if `generateEqualsMethods` is set to true
## 3.2.0
* allow to set an x-caffoa-enum-aliases attribute on string enums. see [readme](readme.md#advanced-enum-configuration) for details.

## 3.1.1
* Fix stream already disposed error in caffoa client if the response is returned as stream

## 3.1.0
* new attribute: `x-caffoa-alias`. Will point the getter and setter to the alias property, useful for deprecated properties that are replaced with new ones. 

## 3.0.1
* add constructor to DefaultCaffoaParser to maintain binary compatibility with 2.x versions

## 3.0.0

The CLI does not support dotnet core 3.1 anymore, thus the major version bump.

* drop support of netcore 3.1 for CLI
* experimental support for ASPCore controller generation, see [readme](readme.md#crated-aspnet-controller-template) for details
* Support for serializing/deserializing nested oneOf data types using a copy of Subtypes library from (https://github.com/manuc66/JsonSubTypes)
* new flag `removeRequiredOnReadonly` (default  `false`) when set to `true`, `Required` attributes will not be generated on members that are required and readOnly
* Fix for client generation if `withCancellation` is set to `false`
* Fix for client generation of Key/Value Pairs
* add jsonSerializerSettings to DefaultCaffoaParser for Json.NET
* added new parameters to generate fully resolved openapi files. This is useful if you want to use the generated files in other tools that do not support references to external files.
  * `generateResolvedApiFile` (default `false`) will resolve external references and generate a single file named `originalName.generated.yml`
  * `simplifyResolvedApiFile` (default `false`) will remove all schema declarations from requestBodies and responses. This is espaciallay usefulle for Azure APIM, to work around the bicep file size restrictions. 

## 2.12.0
* new attribute: `x-caffoa-generate`. If set to false, the property will not be generated
* new attribute: `x-caffoa-delegate`. If set to true, the implementation of the property getter and setter will be delegated to user-written partial method.

## 2.11.0
* allow to set deepCopy default value via `deepCopyDefaultValue` config option. Default is true due to backward compatibility
* x-caffoa-attribute annotation to put a single attribute on a generated member

## 2.10.2
* Client: do not catch correctly thrown CaffoaWebClientException< T > 

## 2.10.1
* fixes to Json serializer not using settings in test library
 
## 2.10.0
* new parameter: "passTags". When set to true, The interface function will have a parameter that contains all openapi tags of that function
* Client: CaffoaWebClientException< T > now inherits from CaffoaWebClientException instead of directly from Exception

## 2.9.0
* Initialize array defaults for primitive types as value array
* new parameter `useConstants: true`. When set to true, values with one single enum and a matching default value will be generated as constants instead of enums. The default is false, to keep backwards compatibility. 

## 2.8.1
* Fix "An expression tree cannot contain pattern-matching 'is' expression"

## 2.8.0
* Json.NET: New CaffoaEarlySerializingResultHandler. The handler serializes the Json data into a string, and returns a ContentResult instead of a JSON result. A JsonResult will serialize the data very late, with no possibility to catch any serialization exceptions. This handler removes the problem with functions returning error 500, but reporting the function call as successful. It can be used by registering it in the startup function via `AddCaffoaResultHandler`

## 2.7.1
* Fixes bug where required properties were not handled correctly for allOf objects

## 2.7.0
* Always use null conditional copy, even on required objects to avoid null pointer exceptions
* Allow to not use default constructors on required objects, using new `constructorOnRequiredObjects` config option (default true, to contain backwards compatibility)

## 2.6.1
* Return parsed timestamps already converted to UTC

## 2.6.0
* Copy/Clone Extensions are now also generated for chained dependencies over files
* New Extension for each Type: SelectAs{TypeA}, to be used with IQueryable<{TypeB}>, for convenient use with IQueryable concatenations

## 2.5.1
* fix: Return IActionResult instead of (IActionResult,int) on multiple return codes with non-parsable content

## 2.5.0
* dependency updates
* deep copy of lists and maps now use null checking

## 2.4.6
* allow string lists as query parameters

## 2.4.5
* allow for nullable enums that are declared as own schema

## 2.4.4
* Remove reference to Caffoa.JsonConverter from enum classes

## 2.4.3 / 2.4.2
* Bugfix resolving external properties that are not objects

## 2.4.1
* Bugfix for properties that are defined in a different openapi file

## 2.4.0
* Support for `type: number format: decimal`

## 2.3.0
* Changed from simple console information to ConsoleLogger
* Allow to generate client without generating function

## 2.2.3
* No changes, nuget release issue due to https://github.com/dotnet/sdk/issues/30625

## 2.2.2
* Fix issue with enum list in query, when the array item is an enum and defined in a different file

## 2.2.1
* Correctly format DateTime, DateTimeOffset, Enums, and EnumLists in path and query parameters of clients
* Fix server and client generation if response is a reference to an external file

## 2.2.0
* Possibility to generate a client (experimental)
* Split up some interfaces to have less bloated interfaces

## 2.1.0
* Added enum arrays for query parameters. can be valid json or comma seperated list.
* namespace is now optional and will be guessed from path information if missing

## 2.0.1
* Fixed default generation if enum is defined outside of object

## 2.0.0
### Breaking Changes

* Renamed `CdIts.Caffoa` dll to `CdIts.Caffoa.Json.Net`
* Renamed `CdIts.Caffoa.Abstractions` dll to `CdIts.Caffoa.Base`
* Moved functionality that does not rely on Json.NET to `CdIts.Caffoa.Base`
* Experimental support of System.Text.Json. See [System.Text.Json README](readme.system.text.json.md)
* use of c# enums for query and path parameters, if the enum is declared as it's own schema elements, and enumMode is empty or set to Default
* Removed parameters:
  *  `acceptCaseInvariantEnums`: This will now always be treated as true, as Json.NET enums are treated as case-insensitive, and enums are the new default
  *  `removeDeprecated`: the deprecated values for static string for enums are removed
  *  `enumsAsStaticValues` and `checkEnums` was moved into `enumMode` with the possible values
     * `Default` = uses c# enums, was `enumsAsStaticValues`: `false`, **is the new default for enums**
     * `StaticValues` = uses static values, was `enumsAsStaticValues`: `true` and `checkEnums`: `true`
     * `StaticValuesWithoutCheck` = uses static values bus does not check the input, was `enumsAsStaticValues`: `true` and `checkEnums`: `false`

* Change of defaults for several configuration parameters. 
  *  `useInheritance` : `false`  
  *  `withCancellation`: `true`
  *  `parsePathParameters`: `true`
  *  `parseQueryParameters`: `true`
  *  `genericAdditionalPropertiesType` : `JToken`
  *  `clearGeneratedFiles` : `true`
  *  `useDateOnly` : `true`
  *  `enumMode`: `Default` (was `enumsAsStaticValues`: `false`)

* For `date-time` objects, the `DateTimeOffset` class is now used instead of `DateTime`. Use config option `useDateTime` to go back to `DateTime`.
* new static class `EnumConverter` to convert string to enums and get defined string values from enums via `enumName.Value()`
* New interface method in `ICaffoaConverter` to convert strings to enums.
* Signatures of `ICaffoaJsonParser` have changed. Default parsing from stream is now done using `JsonTextReader`. From Object now takes the more generic type JToken isntead of JObject. 
* `ParseDate` and `ParseDateTime` interface method in `ICaffoaConverter` now return `DateTimeOffset`
* Dropped support for enums on number types (double/float)

### other changes
* Allow enums in arrays, if the enum is declared as it's own schema elements
* Support for nullable DateOnly and TimeOnly values
* Support for "Any" properties `propName: {}`. Will be added as `JToken` (or `JsonElement?`for System.Text.Json).
* Support for duration formats (TimeSpan)

## 1.x

### 1.9.0
* Refactoring, removed code smells
* added `--initwithfile` and `--initprojectname` to command line, to create a new caffoa.yml based on an openapi file
* it is now possible to load openapi definitions from urls
* nested arrays are now possible
* when cloning an object, dictionaries are now cloned as well.
* when cloning models, models in lists are now cloned as well instead of shallow copied
* prototype for IAsyncEnumerable for return of lists via `asyncArrays: true`
* correctly parse additional properties if additional properties is array, overwritten primitive type of combination of both
* Allow to use C# enums for string and integers, using `enumsAsStaticValues: false`
* prefix filter for durableClient and requestBodyType operation selection

### 1.8.0
* Allow to set the function authorization level

### 1.7.0
* Allow to ignore the case of string enums

### 1.6.0
* added time parser for `type: string format: time` that uses DateTimeOnly or Timespan to represent times in the format HH:mm:ss. Parser also accepts h:m.
* do not fail on body different from application/json. Instead, warn an generate endpoint with Stream
* results with different types than `application/json` will now be generated, raising a warning and generate the function with IActionResult as return value.
* allow for custom converters, using `x-caffoa-converter` annotation in openapi
* allow for custom attributes, using `x-caffoa-attributes` annotation in openapi
* deprecated properties will have an `[Obsolete]` attributes
* Updated underlying OpenApi library
* new config option `useInheritance: false`. This will create a different kind of object for `allOf`. Instead of inheritance, allOf will create a standalone object. constructors will be generated to initialize referenced objects, as well as To<ReferencedObject> methods.
This also now allows for using multiple references in `allOf` and gets rid of complicated inheritance chains.

### 1.5.0
* possibility to have IAsyncDisposable instances
* cleanup of model generation. 
  * The UpdateWith<Name> elements have been moved to extensions. a file called `Extensions.generated.cs` will be created for each namepsace containing these etension methods. If oyu do not need or want them, set `extensions` in your config to false. Future versions of caffoa will have false as default.
  * Copy constructors and Base class constructors have been added
  * To<Name> now uses the copy constructors.
  * The `MergeWith<Name>` methods have been moved to extensions and have been deprecated. A new nuget package called CdIts.Caffoa.Extensions contains new generic `MergedWith<T>` methods.
* Enum values have been moved to own classes for better code completion and cleaner model classes. The code for checking still remains in the model class for now. The old static names have been deprecated.

### 1.4.0
* new option `functionNamePrefix` that adds a prefix to all function names (Not interfaces). Useful if you have multiple APIs in one function that have identical operation IDs
* possibility to add Caffoa Handlers through `services.AddCaffoaFactory<interface, implementantion>` and other `AddCaffoa*` extensions.

### 1.3.0
* new option: `genericAdditionalProperties` will create a dictionary for properties if `additionalProperties`is set to true or omitted. By default, JToken will be used, but you can use your own tyoe (e.g. `object`) by specifiying `genericAdditionalPropertiesType`
* new option: `withCancellation` will add a cancellation token to the method interfaces that indices if the request has been cancelled.

### 1.2.1
* added CLI builds for net6 and net5 for systems that can have net6/net5 without dotnetcore3.1 runtimes

### 1.2.0
* new option: `splitByTag`. When this config option is set to true, multiple interfaces and function classes will be generated based on the first tag of each path
* Fix: Use proper Guid Parsing.
* Model interfaces now have a To{INTERFACENAME}() method, allowing oneOf objects as part of other objects.

### 1.1.0
* new option: use `parsePathParameters` to let caffoa handle the path parameter parsing instead of azure functions.
Additionally, you can individualize the parsing, by implementing your own logic.
* new option: use `parseQueryParameters` to parse query parameters and add them to the interface parameters.
Additionally, required path options then raise an error via the ErrorHandler interface when empty.
* possibility to add DurableClient interface to function invocation and interfaces to use durable functions
* Bugfix: imports are now added to Functions, if they are specified in the configs section. 
* Change: The the HandleErrorMessage of IErrorHandler does now return a bool to indicate if the exception was handled.

### 1.0.4
* Handle special chars in properties, classes and operations

### 1.0.3
* Allow for properties other than basic types in additionalProperties

### 1.0.2
* Fixed: semicolons are not added twice anymore on `_resultHandler.StatusCode(result)`

### 1.0.1
* Fixed: imports that where defined in the global config section are not ignored anymore

### 1.0.0
Initial release
