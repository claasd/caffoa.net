#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV1b.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class L2Address {
        public const string L2AddressObjectName = "address";

        [JsonProperty("street", Required = Required.Always)]
        public virtual string Street { get; set; }

        [JsonProperty("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonProperty("postalCode", Required = Required.Always)]
        public virtual string PostalCode { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public virtual string City { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public virtual string Country { get; set; }

        [JsonIgnore]
        private string _addressType;

        [JsonProperty("addressType")]
        public virtual string AddressType {
            get => _addressType;
            set {
                var _value = AddressTypeValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!AddressTypeValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", AddressTypeValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("addressType",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _addressType = _value;
            }
        }

        [JsonProperty("flags")]
        public virtual Dictionary<string, L2Flags> Flags { get; set; } = new Dictionary<string, L2Flags>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2Address(){}
        public L2Address(L2Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2Address ToL2Address() => new L2Address(this);
    }
}
