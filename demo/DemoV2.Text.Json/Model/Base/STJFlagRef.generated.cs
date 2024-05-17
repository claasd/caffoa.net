#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DemoV2.Text.Json.Model.Base {
/// AUTOGENERED BY caffoa ///
    public partial class STJFlagRef {
        public const string STJFlagRefObjectName = "flagRef";
        [JsonPropertyName("flag")]
        public virtual STJFlags Flag { 
            get => GetFlag(); 
            set => SetFlag(value);
        }
        public partial STJFlags GetFlag();
        partial void SetFlag(STJFlags value);

        [JsonPropertyName("flag2")]
        public virtual STJFlags Flag2 { 
            get => Flag; 
            set => Flag = value;
        }


        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJFlagRef(){}
        public STJFlagRef(STJFlagRef other) {
            Flag = other.Flag?.ToSTJFlags();
            Flag2 = other.Flag2?.ToSTJFlags();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJFlagRef ToSTJFlagRef() => new STJFlagRef(this);
    }
}
