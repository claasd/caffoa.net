using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoIsolated.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IsoMyEnumTypeWithDefault {
        [EnumMember(Value = "true")] True,
        [EnumMember(Value = "false")] False,
        [EnumMember(Value = "undefined")] Undefined
    }
}
