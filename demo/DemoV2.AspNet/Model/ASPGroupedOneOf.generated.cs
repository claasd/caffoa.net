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
    public partial class ASPGroupedOneOf {
        public const string ASPGroupedOneOfObjectName = "groupedOneOf";
        [JsonPropertyName("element")]
        public virtual ASPAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPGroupedOneOf(){}
        public ASPGroupedOneOf(ASPGroupedOneOf other) {
            Element = other.Element?.ToASPAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPGroupedOneOf ToASPGroupedOneOf() => new ASPGroupedOneOf(this);
    }
}
