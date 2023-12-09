#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Address : IEquatable<Address> {
        public const string AddressObjectName = "address";
        [JsonProperty("street", Required = Required.Always)]
        public string Street { get; set; }

        [JsonProperty("street.extra")]
        public string StreetExtra { get; set; }

        [JsonProperty("postalCode", Required = Required.Always)]
        public string PostalCode { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty("addressType")]
        public AddressTypeValue AddressType { get; set; }

        [JsonProperty("flags")]
        public Dictionary<string, Flags> Flags { get; set; } = new Dictionary<string, Flags>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public Address(){}
        public Address(Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (Address.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFlags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public Address ToAddress() => new Address(this);
        public bool Equals(Address other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Street == other.Street && StreetExtra == other.StreetExtra && PostalCode == other.PostalCode && City == other.City && Country == other.Country && AddressType == other.AddressType && Flags.SequenceEqual(other.Flags);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Address other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Address);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Street);
            hashCode.Add(StreetExtra);
            hashCode.Add(PostalCode);
            hashCode.Add(City);
            hashCode.Add(Country);
            hashCode.Add((int) AddressType);
            hashCode.Add(Flags);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
        public static bool operator==(Address a, Address b) => Equals(a, b);
        public static bool operator!=(Address a, Address b) => !Equals(a, b);
    }
}
