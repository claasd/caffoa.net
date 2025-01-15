using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SomeEnum {
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "second")] Second
    }
}
