#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoIsolated.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class IsoAddress {
        public const string IsoAddressObjectName = "address";
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
        public virtual Dictionary<string, IsoFlags> Flags { get; set; } = new Dictionary<string, IsoFlags>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoAddress(){}
        public IsoAddress(IsoAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (IsoAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoAddress ToIsoAddress() => new IsoAddress(this);
    }
}
