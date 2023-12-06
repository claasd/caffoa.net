#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public partial class IsoGroupedOneOf {
        public const string IsoGroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public virtual IsoAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoGroupedOneOf(){}
        public IsoGroupedOneOf(IsoGroupedOneOf other) {
            Element = other.Element?.ToIsoAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoGroupedOneOf ToIsoGroupedOneOf() => new IsoGroupedOneOf(this);
    }
}
