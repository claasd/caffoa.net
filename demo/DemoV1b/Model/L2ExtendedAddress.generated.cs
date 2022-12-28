#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2ExtendedAddress {
        public const string L2ExtendedAddressObjectName = "extendedAddress";

        [JsonProperty("street")]
        public virtual string Street { get; set; }

        [JsonProperty("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonProperty("postalCode")]
        public virtual string PostalCode { get; set; }

        [JsonProperty("city")]
        public virtual string City { get; set; }

        [JsonProperty("country")]
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

        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public L2ExtendedAddress(){}
        public L2ExtendedAddress(L2ExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
            AddressType2 = other.AddressType2;
        }
        public L2ExtendedAddress(L2Address other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags()) : other.Flags;
        }
        public L2Address ToL2Address() => new L2Address() {
            Street = Street,
            StreetExtra = StreetExtra,
            PostalCode = PostalCode,
            City = City,
            Country = Country,
            AddressType = AddressType,
            Flags = Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags())
        };
        public L2Address AsL2Address() => new L2Address() {
            Street = Street,
            StreetExtra = StreetExtra,
            PostalCode = PostalCode,
            City = City,
            Country = Country,
            AddressType = AddressType,
            Flags = Flags
        };
        public L2ExtendedAddress ToL2ExtendedAddress() => new L2ExtendedAddress(this);
    }
}
