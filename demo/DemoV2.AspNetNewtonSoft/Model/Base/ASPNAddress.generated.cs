#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNAddress {
        public const string ASPNAddressObjectName = "address";
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
        public virtual Dictionary<string, ASPNFlags> Flags { get; set; } = new Dictionary<string, ASPNFlags>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNAddress(){}
        public ASPNAddress(ASPNAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPNAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNAddress ToASPNAddress() => new ASPNAddress(this);
    }
}
