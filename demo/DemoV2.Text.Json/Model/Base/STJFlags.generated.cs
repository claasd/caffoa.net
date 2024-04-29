#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJFlags {
        public const string STJFlagsObjectName = "flags";
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        public STJFlags(){}
        public STJFlags(STJFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public STJFlags ToSTJFlags() => new STJFlags(this);
        public bool Equals(STJFlags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJFlags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJFlags);
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
