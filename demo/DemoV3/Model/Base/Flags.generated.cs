#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV3.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Flags {
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
    }
}
