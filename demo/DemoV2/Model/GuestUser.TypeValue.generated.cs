using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace DemoV2.Model {
    public partial class GuestUser {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "guest")] Guest
        }
    }
}