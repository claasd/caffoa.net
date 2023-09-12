#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNExtendedAddress {
        public const string ASPNExtendedAddressObjectName = "extendedAddress";
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

        [JsonProperty("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonProperty("flags")]
        public virtual Dictionary<string, ASPNFlags> Flags { get; set; } = new Dictionary<string, ASPNFlags>();

        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public ASPNExtendedAddress(){}
        public ASPNExtendedAddress(ASPNExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags());
            AddressType2 = other.AddressType2;
        }
        public ASPNExtendedAddress(ASPNAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags;
        }
        public ASPNExtendedAddress ToASPNExtendedAddress() => new ASPNExtendedAddress(this);
    }
}
