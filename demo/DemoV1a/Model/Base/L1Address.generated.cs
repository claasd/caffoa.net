using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV1a.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1Address {
        public const string L1AddressObjectName = "address";

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

        [JsonProperty("flags")]
        public virtual Dictionary<string, L1Flags> Flags { get; set; } = new Dictionary<string, L1Flags>();

        public L1Address(){}
        public L1Address(L1Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL1Flags());
        }
        public L1Address ToL1Address() => new L1Address(this);
    }
}
