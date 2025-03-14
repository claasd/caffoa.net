#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV1b.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class L2FlagRef : IEquatable<L2FlagRef> {
        public const string L2FlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public L2Flags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial L2Flags GetFlag();
        partial void SetFlag(L2Flags value);

        [JsonProperty("flag2")]
        public L2Flags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2FlagRef(){}
        public L2FlagRef(L2FlagRef other) {
            Flag = other.Flag?.ToL2Flags();
            Flag2 = other.Flag2?.ToL2Flags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2FlagRef ToL2FlagRef() => new L2FlagRef(this);
        public bool Equals(L2FlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2FlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2FlagRef);
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
