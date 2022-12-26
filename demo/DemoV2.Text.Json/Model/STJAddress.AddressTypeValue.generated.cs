using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model.Base {
    public partial class STJAddress {
        // enum values for "addressType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}