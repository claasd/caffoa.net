# caffoa: System.Text.Json Support
Currently, the System.Text.Json support is experimental, as it has not been tested thoroughly. However, with net7 and above, caffoa supports System.Text.Json out of the box. For net6 and below, there are some limitations.
## net7.0 and newer
* With net7 and net8 improvements, it is now possible to use all features of caffoa with System.Text.Json with one exception:
* It is not possible to use the object inheritance model for `allOf` objects (`useInheritance: true` config option). As this option is not recommended anymore, this should not be a problem for most users.
* If you want To use system.text.json, set the `flavor: SystemTextJson` config option and use `CdIts.Caffoa.System.Text.Json` library instead of `CdIts.Caffoa.Json.Net`

## Limitations for net6.0 and previous
* Missing required properties will not raise an error, as System.Text.Json support for required properties [starts with net7.0](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/required-properties)
 * Using object inheritance for `allOf` will not work properly. However, as the new standard for `allOf` is standalone objects, this may not be of concern anymore.
* `oneOf` serialization of interfaces is done through a custom converter that uses `Convert.ChangeType` to the actual type, working around the polymorphic problem. Additionally for net7 and above, `[JsonDerivedType]` attributes are set on interfaces.
* Not all types where tested, some may work some may not. DateOnly, TimeOnly and enums will work through custom caffoa converters.
* To use system.text.json, set the `flavor: SystemTextJsonPre7` config option and use `CdIts.Caffoa.System.Text.Json` library instead of `CdIts.Caffoa.Json.Net`



