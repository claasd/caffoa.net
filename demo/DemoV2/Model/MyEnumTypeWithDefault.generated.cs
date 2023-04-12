using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyEnumTypeWithDefault {
        [EnumMember(Value = "true")] True,
        [EnumMember(Value = "false")] False,
        [EnumMember(Value = "undefined")] Undefined
    }
}
