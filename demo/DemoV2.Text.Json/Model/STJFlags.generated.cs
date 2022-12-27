#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class STJFlags {
        public const string STJFlagsObjectName = "flags";

        [JsonPropertyName("id")]
        public virtual string Id { get; set; }

        [JsonPropertyName("desc")]
        public virtual string Desc { get; set; }

        public STJFlags(){}
        public STJFlags(STJFlags other) {
            Id = other.Id;
            Desc = other.Desc;
        }
        public STJFlags ToSTJFlags() => new STJFlags(this);
    }
}
