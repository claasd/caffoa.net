# caffoa: Migration Guide from 1.x.x to 2.x.x

There are a lot of breaking changes between 1.x and 2.x, see the [changelog](changelog.md) see them all.

If oyu migrate from v1.x to v2.x, follw the steps below to keep the 1.x behavior. 

Remove the following entries (if you have them):
```yaml
acceptCaseInvariantEnums: true
removeDeprecated: true
enumsAsStaticValues: false
checkEnums: false
```

Add `enumMode` according to the following table:

| enumsAsStaticValues  | checkEnums             | enumMode                   |
|----------------------|------------------------|----------------------------|
| `false`              | `*`                  | `Default`                  |
| `true`               | `false`              | `StaticValuesWithoutCheck` |
| `true` (1.x default) | `true` (1.x default) | `StaticValues`             |


Set the following variables. If you already have some of them, just keep them at their current value.

```yaml
config:
  enumMode: StaticValues # see above
  useInheritance: true
  withCancellation: false
  parsePathParameters: false
  parseQueryParameters: false
  genericAdditionalPropertiesType: JObject
  clearGeneratedFiles: false
  useDateOnly: false
```

Remove the package-reference to `CdIts.Caffoa` 1.x.x and add add a package-reference to `CdIts.Caffoa.Json.Net` 2.x.x
