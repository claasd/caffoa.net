using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyEnumType {
        [EnumMember(Value = "enum1")] Enum1,
        [EnumMember(Value = "enum2")] Enum2,
        [EnumMember(Value = "enum space")] Enum_space,
        [EnumMember(Value = "enum-sepcial_CHARS")] Enum_sepcial_CHARS
    }
}
