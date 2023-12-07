#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class Flags : IEquatable<Flags> {
        public const string FlagsObjectName = "flags";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public Flags(){}
        public Flags(Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public Flags ToFlags() => new Flags(this);
        public bool Equals(Flags other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Desc == other.Desc;
        }
        public override bool Equals(object obj) => Equals(obj as Flags);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Desc);
            return hashCode.ToHashCode();
        }
        public static bool operator==(Flags a, Flags b) => Equals(a, b);
        public static bool operator!=(Flags a, Flags b) => !Equals(a, b);
    }
}
