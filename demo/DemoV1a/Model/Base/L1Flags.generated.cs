using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV1a.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1Flags {
        public const string L1FlagsObjectName = "flags";

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public L1Flags(){}
        public L1Flags(L1Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public L1Flags ToL1Flags() => new L1Flags(this);
    }
}
