using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV1b.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L2Address {
        public const string L2AddressObjectName = "address";

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
        public virtual Dictionary<string, L2Flags> Flags { get; set; } = new Dictionary<string, L2Flags>();

        public L2Address(){}
        public L2Address(L2Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
        }
        public L2Address ToL2Address() => new L2Address(this);
    }
}
