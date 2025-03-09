#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPNFlagRef : IEquatable<ASPNFlagRef> {
        public const string ASPNFlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public ASPNFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial ASPNFlags GetFlag();
        partial void SetFlag(ASPNFlags value);

        [JsonProperty("flag2")]
        public ASPNFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNFlagRef(){}
        public ASPNFlagRef(ASPNFlagRef other) {
            Flag = other.Flag?.ToASPNFlags();
            Flag2 = other.Flag2?.ToASPNFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNFlagRef ToASPNFlagRef() => new ASPNFlagRef(this);
        public bool Equals(ASPNFlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNFlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNFlagRef);
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
