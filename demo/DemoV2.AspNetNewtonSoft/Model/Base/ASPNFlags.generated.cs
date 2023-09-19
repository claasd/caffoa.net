#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNFlags {
        public const string ASPNFlagsObjectName = "flags";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public ASPNFlags(){}
        public ASPNFlags(ASPNFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public ASPNFlags ToASPNFlags() => new ASPNFlags(this);
    }
}
