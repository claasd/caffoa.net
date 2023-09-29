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
    public partial class ASPNGroupedOneOf {
        public const string ASPNGroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public virtual ASPNAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNGroupedOneOf(){}
        public ASPNGroupedOneOf(ASPNGroupedOneOf other) {
            Element = other.Element?.ToASPNAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNGroupedOneOf ToASPNGroupedOneOf() => new ASPNGroupedOneOf(this);
    }
}
