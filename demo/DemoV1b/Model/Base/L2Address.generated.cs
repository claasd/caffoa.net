#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace DemoV1b.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class L2Address : IEquatable<L2Address> {
        public const string L2AddressObjectName = "address";
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

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2Address(){}
        public L2Address(L2Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            NumericPostalCode = other.NumericPostalCode;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            AddressType = other.AddressType;
            Flags = other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL2Flags());
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2Address ToL2Address() => new L2Address(this);
        public bool Equals(L2Address other) {
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
        partial void _PartialEquals(L2Address other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2Address);
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
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
