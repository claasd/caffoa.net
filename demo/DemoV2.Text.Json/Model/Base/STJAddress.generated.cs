#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV2.Text.Json.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class STJAddress {
        public const string STJAddressObjectName = "address";
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

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJAddress(){}
        public STJAddress(STJAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (STJAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJAddress ToSTJAddress() => new STJAddress(this);
    }
}
