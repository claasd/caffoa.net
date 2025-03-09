#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV1a.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class L1FlagRef : IEquatable<L1FlagRef> {
        public const string L1FlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public virtual L1Flags Flag { get; set; }

        [JsonProperty("flag2")]
        public virtual L1Flags Flag2 { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1FlagRef(){}
        public L1FlagRef(L1FlagRef other) {
            Flag = other.Flag?.ToL1Flags();
            Flag2 = other.Flag2?.ToL1Flags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1FlagRef ToL1FlagRef() => new L1FlagRef(this);
        public bool Equals(L1FlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1FlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1FlagRef);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Flag);
            hashCode.Add(Flag2);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
