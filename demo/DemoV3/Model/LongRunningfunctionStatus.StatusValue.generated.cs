using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace DemoV3.Model {
    public partial class LongRunningfunctionStatus {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "running")] Running,
            [EnumMember(Value = "success")] Success,
            [EnumMember(Value = "failure")] Failure
        }
    }
}