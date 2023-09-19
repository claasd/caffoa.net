#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPExtendedAddress {
        public const string ASPExtendedAddressObjectName = "extendedAddress";
        [JsonPropertyName("street")]
        public virtual string Street { get; set; }

        [JsonPropertyName("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonPropertyName("postalCode")]
        public virtual string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public virtual string City { get; set; }

        [JsonPropertyName("country")]
        public virtual string Country { get; set; }

        [JsonPropertyName("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonPropertyName("flags")]
        public virtual Dictionary<string, ASPFlags> Flags { get; set; } = new Dictionary<string, ASPFlags>();

        [JsonPropertyName("addressType2")]
        public virtual string AddressType2 { get; set; }

        public ASPExtendedAddress(){}
        public ASPExtendedAddress(ASPExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags());
            AddressType2 = other.AddressType2;
        }
        public ASPExtendedAddress(ASPAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
        }
        public ASPExtendedAddress ToASPExtendedAddress() => new ASPExtendedAddress(this);
    }
}
