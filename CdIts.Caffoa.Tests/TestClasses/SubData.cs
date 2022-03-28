using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests.TestClasses;

public class SubData
{
    [JsonProperty("data", Required = Required.Always)]
    public string? Data { get; set; }
}
