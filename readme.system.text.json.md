# caffoa: System.Text.Json Support

Currently, the System.Text.Json support is experimental. Most things will work. However, some things are not supported, as System.Text.Json does not support them.

* Missing required properties will not raise an error, as System.Text.Json support for required properties [starts with net7.0](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/required-properties), but function support is currently for net6.0.
* The same is true for [polymorphic serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism?pivots=dotnet-7-0). Using object inheritance for `allOf` will not work properly.
* `oneOf` serialization of interfaces is done through a custom converter that uses `Convert.ChangeType` to the actual type, working around the polymorphic problem.
* Not all types where tested, some may work some may not. DateOnly, TimeOnly and enums will work through custom caffoa converters.

To use system.text.json, set the `flavor: SystemTextJson` config option and use `CdIts.Caffoa.System.Text.Json` library instead of `CdIts.Caffoa.Json.Net`


