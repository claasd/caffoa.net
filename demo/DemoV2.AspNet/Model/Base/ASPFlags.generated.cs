#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoV2.AspNet.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPFlags {
        public const string ASPFlagsObjectName = "flags";
        [JsonPropertyName("id")]
        public virtual string Id { get; set; }

        [JsonPropertyName("desc")]
        public virtual string Desc { get; set; }

        public ASPFlags(){}
        public ASPFlags(ASPFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public ASPFlags ToASPFlags() => new ASPFlags(this);
    }
}
