#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNFlagRef {
        public const string ASPNFlagRefObjectName = "flagRef";
        [JsonProperty("flag")]
        public virtual ASPNFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial ASPNFlags GetFlag();
        partial void SetFlag(ASPNFlags value);

        [JsonProperty("flag2")]
        public virtual ASPNFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }


        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNFlagRef(){}
        public ASPNFlagRef(ASPNFlagRef other) {
            Flag = other.Flag?.ToASPNFlags();
            Flag2 = other.Flag2?.ToASPNFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNFlagRef ToASPNFlagRef() => new ASPNFlagRef(this);
    }
}
