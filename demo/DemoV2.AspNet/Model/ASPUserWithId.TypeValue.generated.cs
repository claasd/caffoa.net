using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    public partial class ASPUserWithId {
        // enum values for "type"
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "simple")] Simple
        }
    }
}