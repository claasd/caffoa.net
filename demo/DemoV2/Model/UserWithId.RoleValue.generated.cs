using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    public partial class UserWithId {
        // enum values for "role"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleValue {
            [EnumMember(Value = "admin")] Admin,
            [EnumMember(Value = "reader")] Reader,
            [EnumMember(Value = "contributor")] Contributor
        }
    }
}