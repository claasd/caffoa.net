using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.AspNetNewtonSoft.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ASPNMyNullableEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
