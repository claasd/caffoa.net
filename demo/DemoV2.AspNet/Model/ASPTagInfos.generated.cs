#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPTagInfos {
        public const string ASPTagInfosObjectName = "tagInfos";
        [JsonPropertyName("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPTagInfos(){}
        public ASPTagInfos(ASPTagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPTagInfos ToASPTagInfos() => new ASPTagInfos(this);
    }
}
