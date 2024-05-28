#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.AspNet.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class ASPFlagRef {
        public const string ASPFlagRefObjectName = "flagRef";
        [JsonPropertyName("flag")]
        public virtual ASPFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial ASPFlags GetFlag();
        partial void SetFlag(ASPFlags value);

        [JsonPropertyName("flag2")]
        public virtual ASPFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPFlagRef(){}
        public ASPFlagRef(ASPFlagRef other) {
            Flag = other.Flag?.ToASPFlags();
            Flag2 = other.Flag2?.ToASPFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPFlagRef ToASPFlagRef() => new ASPFlagRef(this);
    }
}
