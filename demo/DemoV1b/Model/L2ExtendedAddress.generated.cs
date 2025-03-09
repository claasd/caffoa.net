#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class L2ExtendedAddress : IEquatable<L2ExtendedAddress> {
        public const string L2ExtendedAddressObjectName = "extendedAddress";
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

        [JsonIgnore]
        private string _addressType;

        [JsonProperty("addressType")]
        public string AddressType {
            get => _addressType;
            set {
                var _value = AddressTypeValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!AddressTypeValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", AddressTypeValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("addressType",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _addressType = _value;
            }
        }

        [JsonProperty("flags")]
        public Dictionary<string, L2Flags> Flags { get; set; } = new Dictionary<string, L2Flags>();

        [JsonProperty("addressType2")]
        public string AddressType2 { get; set; }

        public L2ExtendedAddress(){}
        public L2ExtendedAddress(L2ExtendedAddress other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL2Flags());
            AddressType2 = other.AddressType2;
        }
        public L2ExtendedAddress(L2Address other, bool deepClone = true) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL2Flags()) : other.Flags;
        }
        public L2ExtendedAddress ToL2ExtendedAddress() => new L2ExtendedAddress(this);
        public bool Equals(L2ExtendedAddress other) {
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
        partial void _PartialEquals(L2ExtendedAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2ExtendedAddress);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Street);
            hashCode.Add(StreetExtra);
            hashCode.Add(NumericPostalCode);
            hashCode.Add(PostalCode);
            hashCode.Add(City);
            hashCode.Add(Country);
            hashCode.Add(AddressType);
            hashCode.Add(Flags);
            hashCode.Add(AddressType2);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
