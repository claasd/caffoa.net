using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoIsolated.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IsoMyNullableEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
