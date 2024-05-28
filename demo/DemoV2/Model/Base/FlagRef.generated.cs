#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FlagRef : IEquatable<FlagRef> {
        public const string FlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public Flags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial Flags GetFlag();
        partial void SetFlag(Flags value);

        [JsonProperty("flag2")]
        public Flags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public FlagRef(){}
        public FlagRef(FlagRef other) {
            Flag = other.Flag?.ToFlags();
            Flag2 = other.Flag2?.ToFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public FlagRef ToFlagRef() => new FlagRef(this);
        public bool Equals(FlagRef other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Flag?.Equals(other.Flag) ?? other.Flag is null)
                && (Flag2?.Equals(other.Flag2) ?? other.Flag2 is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FlagRef other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FlagRef);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Flag);
            hashCode.Add(Flag2);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
        public static bool operator==(FlagRef a, FlagRef b) => Equals(a, b);
        public static bool operator!=(FlagRef a, FlagRef b) => !Equals(a, b);
    }
}
