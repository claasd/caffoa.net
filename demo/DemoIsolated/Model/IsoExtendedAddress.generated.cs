#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class IsoExtendedAddress : IEquatable<IsoExtendedAddress> {
        public const string IsoExtendedAddressObjectName = "extendedAddress";
        [JsonProperty("street", Required = Required.Always)]
        public string Street { get; set; }

        [JsonProperty("street.extra")]
        public string StreetExtra { get; set; }

        [JsonProperty("numericPostalCode")]
        public int NumericPostalCode { 
            get => int.Parse(PostalCode); 
            set => PostalCode = $"{value:D5}";
        }

        [JsonProperty("postalCode", Required = Required.Always)]
        public string PostalCode { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty("addressType")]
        public AddressTypeValue AddressType { get; set; }

        [JsonProperty("flags")]
        public Dictionary<string, IsoFlags> Flags { get; set; } = new Dictionary<string, IsoFlags>();

        [JsonProperty("addressType2")]
        public string AddressType2 { get; set; }

        public IsoExtendedAddress(){}
        public IsoExtendedAddress(IsoExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags());
            AddressType2 = other.AddressType2;
        }
        public IsoExtendedAddress(IsoAddress other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
        }
        public IsoExtendedAddress ToIsoExtendedAddress() => new IsoExtendedAddress(this);
        public bool Equals(IsoExtendedAddress other) {
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
        partial void _PartialEquals(IsoExtendedAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoExtendedAddress);
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
