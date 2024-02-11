#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPNFlags {
        public const string ASPNFlagsObjectName = "flags";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        public ASPNFlags(){}
        public ASPNFlags(ASPNFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public ASPNFlags ToASPNFlags() => new ASPNFlags(this);
        public bool Equals(ASPNFlags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNFlags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNFlags);
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
