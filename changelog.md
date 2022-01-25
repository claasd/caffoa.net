# caffoa changelog

### 1.1.0
* new option: use `parsePathParameters` to let caffoa handle the path parameter parsing instead of azure functions.
Additionally, you can individualize the parsing, by implementing your own logic.
* new option: use `parseQueryParameters` to parse query parameters and add them to the interface parameters.
Additionally, required path options then raise an error via the ErrorHandler interface when empty.
* possibility to add DurableClient interface to function invocation and interfaces to use durable functions
* Bugfix: imports are now added to Functions, if they are specified in the configs section. 

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
