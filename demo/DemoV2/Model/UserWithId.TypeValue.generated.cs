using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    public partial class UserWithId {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "simple")] Simple
        }
    }
}