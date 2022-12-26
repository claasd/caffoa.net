using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    public partial class STJUser {
        // enum values for "role"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleValue {
            [EnumMember(Value = "admin")] Admin,
            [EnumMember(Value = "reader")] Reader,
            [EnumMember(Value = "contributor")] Contributor
        }
    }
}