#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1GroupedOneOf {
        public const string L1GroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public virtual L1AnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1GroupedOneOf(){}
        public L1GroupedOneOf(L1GroupedOneOf other) {
            Element = other.Element?.ToL1AnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1GroupedOneOf ToL1GroupedOneOf() => new L1GroupedOneOf(this);
    }
}
