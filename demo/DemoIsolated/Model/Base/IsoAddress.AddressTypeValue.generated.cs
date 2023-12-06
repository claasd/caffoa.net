using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoIsolated.Model.Base {
    public partial class IsoAddress {
        // enum values for "addressType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AddressTypeValue {
            [EnumMember(Value = "regular")] Regular
        }
    }
}