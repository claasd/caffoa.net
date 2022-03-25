using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CdIts.Caffoa.Tests.TestClasses;

public class BaseData
{
    [JsonProperty("d1", Required = Required.Always)]
    public string? D1 { get; set; } = "";

    [JsonProperty("sub")]
    public SubData? SubData;
}
