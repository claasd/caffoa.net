using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace DemoV2.Model.Base {
    public partial class Address {
        // enum values for "addressType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}