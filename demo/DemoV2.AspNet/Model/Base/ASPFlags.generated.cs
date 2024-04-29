#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoV2.AspNet.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPFlags {
        public const string ASPFlagsObjectName = "flags";
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        public ASPFlags(){}
        public ASPFlags(ASPFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public ASPFlags ToASPFlags() => new ASPFlags(this);
        public bool Equals(ASPFlags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPFlags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPFlags);
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
