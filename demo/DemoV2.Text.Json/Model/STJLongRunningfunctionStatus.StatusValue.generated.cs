using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    public partial class STJLongRunningfunctionStatus {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "running")] Running,
            [EnumMember(Value = "success")] Success,
            [EnumMember(Value = "failure")] Failure
        }
    }
}