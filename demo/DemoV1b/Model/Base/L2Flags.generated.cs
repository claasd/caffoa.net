#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV1b.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class L2Flags {
        public const string L2FlagsObjectName = "flags";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        public L2Flags(){}
        public L2Flags(L2Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public L2Flags ToL2Flags() => new L2Flags(this);
        public bool Equals(L2Flags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2Flags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2Flags);
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
