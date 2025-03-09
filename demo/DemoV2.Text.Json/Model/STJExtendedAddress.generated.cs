#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJExtendedAddress : IEquatable<STJExtendedAddress> {
        public const string STJExtendedAddressObjectName = "extendedAddress";
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

        [JsonPropertyName("addressType2")]
        public string AddressType2 { get; set; }

        public STJExtendedAddress(){}
        public STJExtendedAddress(STJExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags());
            AddressType2 = other.AddressType2;
        }
        public STJExtendedAddress(STJAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags()) : other.Flags;
        }
        public STJExtendedAddress ToSTJExtendedAddress() => new STJExtendedAddress(this);
        public bool Equals(STJExtendedAddress other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Street == other.Street
                && StreetExtra == other.StreetExtra
                && NumericPostalCode == other.NumericPostalCode
                && PostalCode == other.PostalCode
                && City == other.City
                && Country == other.Country
                && AddressType == other.AddressType
                && (other.Flags is null ? Flags is null : Flags?.SequenceEqual(other.Flags) ?? other.Flags is null)
                && AddressType2 == other.AddressType2;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJExtendedAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJExtendedAddress);
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
            hashCode.Add(AddressType2);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
