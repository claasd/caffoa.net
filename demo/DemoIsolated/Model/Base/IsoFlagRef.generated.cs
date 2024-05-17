#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoIsolated.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class IsoFlagRef {
        public const string IsoFlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public virtual IsoFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial IsoFlags GetFlag();
        partial void SetFlag(IsoFlags value);

        [JsonProperty("flag2")]
        public virtual IsoFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }


        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoFlagRef(){}
        public IsoFlagRef(IsoFlagRef other) {
            Flag = other.Flag?.ToIsoFlags();
            Flag2 = other.Flag2?.ToIsoFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoFlagRef ToIsoFlagRef() => new IsoFlagRef(this);
    }
}
