#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public partial class IsoExtendedAddress {
        public const string IsoExtendedAddressObjectName = "extendedAddress";
        [JsonProperty("street", Required = Required.Always)]
        public virtual string Street { get; set; }

        [JsonProperty("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonProperty("numericPostalCode")]
        public virtual int NumericPostalCode { 
            get => int.Parse(PostalCode); 
            set => PostalCode = $"{value:D5}";
        }

        [JsonProperty("postalCode", Required = Required.Always)]
        public virtual string PostalCode { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public virtual string City { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public virtual string Country { get; set; }

        [JsonProperty("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonProperty("flags")]
        public virtual Dictionary<string, IsoFlags> Flags { get; set; } = new Dictionary<string, IsoFlags>();

        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public IsoExtendedAddress(){}
        public IsoExtendedAddress(IsoExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags());
            AddressType2 = other.AddressType2;
        }
        public IsoExtendedAddress(IsoAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
        }
        public IsoExtendedAddress ToIsoExtendedAddress() => new IsoExtendedAddress(this);
    }
}
