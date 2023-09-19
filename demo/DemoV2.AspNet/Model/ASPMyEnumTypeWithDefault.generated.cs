using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ASPMyEnumTypeWithDefault {
        [EnumMember(Value = "true")] True,
        [EnumMember(Value = "false")] False,
        [EnumMember(Value = "undefined")] Undefined
    }
}
