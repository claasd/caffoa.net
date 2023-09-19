using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    public partial class ASPLongRunningfunctionStatus {
        // enum values for "status"
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "running")] Running,
            [EnumMember(Value = "success")] Success,
            [EnumMember(Value = "failure")] Failure
        }
    }
}