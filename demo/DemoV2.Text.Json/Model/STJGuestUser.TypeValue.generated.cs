using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    public partial class STJGuestUser {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "guest")] Guest
        }
    }
}