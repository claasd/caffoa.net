using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    public partial class ASPExtendedAddress {
        // enum values for "addressType"
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}