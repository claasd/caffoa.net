#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ExtendedAddress {
        public const string ExtendedAddressObjectName = "extendedAddress";
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

        [JsonProperty("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonProperty("flags")]
        public virtual Dictionary<string, Flags> Flags { get; set; } = new Dictionary<string, Flags>();

        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public ExtendedAddress(){}
        public ExtendedAddress(ExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFlags());
            AddressType2 = other.AddressType2;
        }
        public ExtendedAddress(Address other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFlags()) : other.Flags;
        }
        public ExtendedAddress ToExtendedAddress() => new ExtendedAddress(this);
    }
}
