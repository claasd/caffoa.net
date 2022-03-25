using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CdIts.Caffoa.Tests.TestClasses;

public class Ext1Data : BaseData
{
    [JsonProperty("d2")]
    public string D2 { get; set; } = "";
}
