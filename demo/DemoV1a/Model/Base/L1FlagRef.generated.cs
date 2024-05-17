#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV1a.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class L1FlagRef {
        public const string L1FlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public virtual L1Flags Flag { get; set; }

        [JsonProperty("flag2")]
        public virtual L1Flags Flag2 { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1FlagRef(){}
        public L1FlagRef(L1FlagRef other) {
            Flag = other.Flag?.ToL1Flags();
            Flag2 = other.Flag2?.ToL1Flags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1FlagRef ToL1FlagRef() => new L1FlagRef(this);
    }
}
