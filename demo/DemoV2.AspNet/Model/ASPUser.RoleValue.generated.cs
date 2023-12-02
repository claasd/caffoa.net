using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    public partial class ASPUser {
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