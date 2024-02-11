#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoIsolated.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class IsoFlags {
        public const string IsoFlagsObjectName = "flags";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        public IsoFlags(){}
        public IsoFlags(IsoFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public IsoFlags ToIsoFlags() => new IsoFlags(this);
        public bool Equals(IsoFlags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IsoFlags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoFlags);
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
