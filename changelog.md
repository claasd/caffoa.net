# caffoa changelog

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
