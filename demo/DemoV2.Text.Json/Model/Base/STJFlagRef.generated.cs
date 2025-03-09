#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.Text.Json.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJFlagRef : IEquatable<STJFlagRef> {
        public const string STJFlagRefObjectName = "flagRef";
        [JsonPropertyName("flag")]
        public STJFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial STJFlags GetFlag();
        partial void SetFlag(STJFlags value);

        [JsonPropertyName("flag2")]
        public STJFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJFlagRef(){}
        public STJFlagRef(STJFlagRef other) {
            Flag = other.Flag?.ToSTJFlags();
            Flag2 = other.Flag2?.ToSTJFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJFlagRef ToSTJFlagRef() => new STJFlagRef(this);
        public bool Equals(STJFlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJFlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJFlagRef);
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
