#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoIsolated.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class IsoFlagRef : IEquatable<IsoFlagRef> {
        public const string IsoFlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public IsoFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial IsoFlags GetFlag();
        partial void SetFlag(IsoFlags value);

        [JsonProperty("flag2")]
        public IsoFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoFlagRef(){}
        public IsoFlagRef(IsoFlagRef other) {
            Flag = other.Flag?.ToIsoFlags();
            Flag2 = other.Flag2?.ToIsoFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoFlagRef ToIsoFlagRef() => new IsoFlagRef(this);
        public bool Equals(IsoFlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IsoFlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoFlagRef);
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
