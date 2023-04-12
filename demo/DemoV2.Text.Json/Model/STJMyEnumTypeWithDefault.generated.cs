using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum STJMyEnumTypeWithDefault {
        [EnumMember(Value = "true")] True,
        [EnumMember(Value = "false")] False,
        [EnumMember(Value = "undefined")] Undefined
    }
}
