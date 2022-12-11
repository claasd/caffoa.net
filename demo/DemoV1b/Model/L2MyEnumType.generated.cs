using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace DemoV1b.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum L2MyEnumType {
        [EnumMember(Value = "enum1")] Enum1,
        [EnumMember(Value = "enum2")] Enum2,
        [EnumMember(Value = "enum space")] Enum_space,
        [EnumMember(Value = "enum-sepcial_CHARS")] Enum_sepcial_CHARS
    }
}
