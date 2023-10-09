#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV2.AspNet.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPAddress {
        public const string ASPAddressObjectName = "address";
        [JsonPropertyName("street")]
        [JsonRequired]
        public virtual string Street { get; set; }

        [JsonPropertyName("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonPropertyName("postalCode")]
        [JsonRequired]
        public virtual string PostalCode { get; set; }

        [JsonPropertyName("city")]
        [JsonRequired]
        public virtual string City { get; set; }

        [JsonPropertyName("country")]
        [JsonRequired]
        public virtual string Country { get; set; }

        [JsonPropertyName("addressType")]
        public virtual AddressTypeValue AddressType { get; set; }

        [JsonPropertyName("flags")]
        public virtual Dictionary<string, ASPFlags> Flags { get; set; } = new Dictionary<string, ASPFlags>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPAddress(){}
        public ASPAddress(ASPAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPAddress ToASPAddress() => new ASPAddress(this);
    }
}
