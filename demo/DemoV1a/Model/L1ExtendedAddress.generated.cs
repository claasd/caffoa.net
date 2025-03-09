#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1ExtendedAddress : L1Address, IEquatable<L1ExtendedAddress> {
        public const string L1ExtendedAddressObjectName = "extendedAddress";
        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public L1ExtendedAddress(){}
        public L1ExtendedAddress(L1ExtendedAddress other) : base(other) {
            AddressType2 = other.AddressType2;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1ExtendedAddress(L1Address other) : base(other) {}
        public L1ExtendedAddress ToL1ExtendedAddress() => new L1ExtendedAddress(this);
        public bool Equals(L1ExtendedAddress other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = AddressType2 == other.AddressType2;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1ExtendedAddress other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1ExtendedAddress);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(AddressType2);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
