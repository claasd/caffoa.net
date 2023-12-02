using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum STJMyEnumType {
        [EnumMember(Value = "enum1")] Enum1,
        [EnumMember(Value = "enum2")] Enum2,
        [EnumMember(Value = "enum space")] Enum_space,
        [EnumMember(Value = "enum-sepcial_CHARS")] Enum_sepcial_CHARS,
        [EnumMember(Value = "deprecated_enum")] Deprecated_enum = Enum1,
        [EnumMember(Value = "deprecated_enum2")] Deprecated_enum2 = Enum2
    }
}
