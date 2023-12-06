#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoIsolated.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class IsoFlags {
        public const string IsoFlagsObjectName = "flags";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public IsoFlags(){}
        public IsoFlags(IsoFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public IsoFlags ToIsoFlags() => new IsoFlags(this);
    }
}
