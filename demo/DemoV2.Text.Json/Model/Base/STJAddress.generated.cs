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
    public sealed  partial class STJAddress : IEquatable<STJAddress> {
        public const string STJAddressObjectName = "address";
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("street.extra")]
        public string StreetExtra { get; set; }

        [JsonPropertyName("numericPostalCode")]
        public int NumericPostalCode { 
            get => int.Parse(PostalCode); 
            set => PostalCode = $"{value:D5}";
        }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("addressType")]
        public AddressTypeValue AddressType { get; set; }

        [JsonPropertyName("flags")]
        public Dictionary<string, STJFlags> Flags { get; set; } = new Dictionary<string, STJFlags>();

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
        public bool Equals(STJAddress other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Street == other.Street
                && StreetExtra == other.StreetExtra
                && NumericPostalCode == other.NumericPostalCode
                && PostalCode == other.PostalCode
                && City == other.City
                && Country == other.Country
                && AddressType == other.AddressType
                && (other.Flags is null ? Flags is null : Flags?.SequenceEqual(other.Flags) ?? other.Flags is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJAddress);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Street);
            hashCode.Add(StreetExtra);
            hashCode.Add(NumericPostalCode);
            hashCode.Add(PostalCode);
            hashCode.Add(City);
            hashCode.Add(Country);
            hashCode.Add((int) AddressType);
            hashCode.Add(Flags);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
