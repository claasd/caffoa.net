using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoIsolated.Model {
    public partial class IsoUser {
        // enum values for "role"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleValue {
            [EnumMember(Value = "admin")] Admin,
            [EnumMember(Value = "reader")] Reader,
            [EnumMember(Value = "contributor")] Contributor,
            [EnumMember(Value = "editor")] Editor = Contributor
        }
    }
}