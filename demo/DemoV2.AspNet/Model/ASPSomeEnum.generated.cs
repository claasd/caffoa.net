using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ASPSomeEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
