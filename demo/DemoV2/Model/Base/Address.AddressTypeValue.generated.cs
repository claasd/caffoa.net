using System.Runtime.Serialization;
using Caffoa.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model.Base {
    public partial class Address {
        // enum values for "addressType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}