#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public partial class STJExtendedAddress {
        public const string STJExtendedAddressObjectName = "extendedAddress";
        [JsonPropertyName("street")]
        public virtual string Street { get; set; }

        [JsonPropertyName("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonPropertyName("numericPostalCode")]
        public virtual int NumericPostalCode { 
            get => int.Parse(PostalCode); 
            set => PostalCode = $"{value:D5}";
        }

        [JsonPropertyName("postalCode")]
        public virtual string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public virtual string City { get; set; }

        [JsonPropertyName("country")]
        public virtual string Country { get; set; }

        [JsonPropertyName("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonPropertyName("flags")]
        public virtual Dictionary<string, STJFlags> Flags { get; set; } = new Dictionary<string, STJFlags>();

        [JsonPropertyName("addressType2")]
        public virtual string AddressType2 { get; set; }

        public STJExtendedAddress(){}
        public STJExtendedAddress(STJExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags());
            AddressType2 = other.AddressType2;
        }
        public STJExtendedAddress(STJAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags()) : other.Flags;
        }
        public STJExtendedAddress ToSTJExtendedAddress() => new STJExtendedAddress(this);
    }
}
