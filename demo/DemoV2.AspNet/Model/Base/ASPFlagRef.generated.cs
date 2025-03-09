#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.AspNet.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPFlagRef : IEquatable<ASPFlagRef> {
        public const string ASPFlagRefObjectName = "flagRef";
        [JsonPropertyName("flag")]
        public ASPFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial ASPFlags GetFlag();
        partial void SetFlag(ASPFlags value);

        [JsonPropertyName("flag2")]
        public ASPFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPFlagRef(){}
        public ASPFlagRef(ASPFlagRef other) {
            Flag = other.Flag?.ToASPFlags();
            Flag2 = other.Flag2?.ToASPFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPFlagRef ToASPFlagRef() => new ASPFlagRef(this);
        public bool Equals(ASPFlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPFlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPFlagRef);
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
