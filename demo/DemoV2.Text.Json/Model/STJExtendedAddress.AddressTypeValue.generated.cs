using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    public partial class STJExtendedAddress {
        // enum values for "addressType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}