using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model.Base {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NullableEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
