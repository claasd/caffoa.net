using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ASPNNullableEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
