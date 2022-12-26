using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using Newtonsoft.Json;using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    public partial class GuestUser {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "guest")] Guest
        }
    }
}