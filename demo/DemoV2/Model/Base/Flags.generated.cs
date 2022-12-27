#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
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
