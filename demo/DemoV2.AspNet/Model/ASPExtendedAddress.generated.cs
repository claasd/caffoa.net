#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPExtendedAddress : IEquatable<ASPExtendedAddress> {
        public const string ASPExtendedAddressObjectName = "extendedAddress";
        [JsonPropertyName("street")]
        [JsonRequired]
        public string Street { get; set; }

        [JsonPropertyName("street.extra")]
        public string StreetExtra { get; set; }

        [JsonPropertyName("numericPostalCode")]
        public int NumericPostalCode { 
            get => int.Parse(PostalCode); 
            set => PostalCode = $"{value:D5}";
        }

        [JsonPropertyName("postalCode")]
        [JsonRequired]
        public string PostalCode { get; set; }

        [JsonPropertyName("city")]
        [JsonRequired]
        public string City { get; set; }

        [JsonPropertyName("country")]
        [JsonRequired]
        public string Country { get; set; }

        [JsonPropertyName("addressType")]
        public AddressTypeValue AddressType { get; set; }

        [JsonPropertyName("flags")]
        public Dictionary<string, ASPFlags> Flags { get; set; } = new Dictionary<string, ASPFlags>();

        [JsonPropertyName("addressType2")]
        public string AddressType2 { get; set; }

        public ASPExtendedAddress(){}
        public ASPExtendedAddress(ASPExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags());
            AddressType2 = other.AddressType2;
        }
        public ASPExtendedAddress(ASPAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
        }
        public ASPExtendedAddress ToASPExtendedAddress() => new ASPExtendedAddress(this);
        public bool Equals(ASPExtendedAddress other) {
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
        partial void _PartialEquals(ASPExtendedAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPExtendedAddress);
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
