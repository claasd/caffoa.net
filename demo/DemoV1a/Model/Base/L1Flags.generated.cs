#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV1a.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class L1Flags {
        public const string L1FlagsObjectName = "flags";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public L1Flags(){}
        public L1Flags(L1Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public L1Flags ToL1Flags() => new L1Flags(this);
        public bool Equals(L1Flags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1Flags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1Flags);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Desc);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
