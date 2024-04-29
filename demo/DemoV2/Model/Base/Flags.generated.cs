#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Flags : IEquatable<Flags> {
        public const string FlagsObjectName = "flags";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        public Flags(){}
        public Flags(Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public Flags ToFlags() => new Flags(this);
        public bool Equals(Flags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Desc == other.Desc;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Flags other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Flags);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Desc);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
        public static bool operator==(Flags a, Flags b) => Equals(a, b);
        public static bool operator!=(Flags a, Flags b) => !Equals(a, b);
    }
}
