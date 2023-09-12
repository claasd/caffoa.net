#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNTagInfos {
        public const string ASPNTagInfosObjectName = "tagInfos";
        [JsonProperty("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNTagInfos(){}
        public ASPNTagInfos(ASPNTagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNTagInfos ToASPNTagInfos() => new ASPNTagInfos(this);
    }
}
