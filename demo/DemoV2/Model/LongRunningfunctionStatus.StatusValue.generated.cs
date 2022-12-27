using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
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