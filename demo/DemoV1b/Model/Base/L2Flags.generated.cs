#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV1b.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class L2Flags {
        public const string L2FlagsObjectName = "flags";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public L2Flags(){}
        public L2Flags(L2Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public L2Flags ToL2Flags() => new L2Flags(this);
    }
}
