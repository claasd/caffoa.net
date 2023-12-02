using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    public partial class STJUserWithId {
        // enum values for "role"
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RoleValue {
            [EnumMember(Value = "admin")] Admin,
            [EnumMember(Value = "reader")] Reader,
            [EnumMember(Value = "contributor")] Contributor,
            [EnumMember(Value = "editor")] Editor = Contributor
        }
    }
}