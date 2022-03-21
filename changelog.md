# caffoa changelog

### 1.6.0
* added time parser for `type: string format: time` that uses DateTimeOnly or Timespan to represent times in the format HH:mm:ss. Parser also accepts h:m.

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
