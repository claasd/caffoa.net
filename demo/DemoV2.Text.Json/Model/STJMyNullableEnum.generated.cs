using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum STJMyNullableEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
