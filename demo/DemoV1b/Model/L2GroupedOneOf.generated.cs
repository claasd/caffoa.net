#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2GroupedOneOf {
        public const string L2GroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public virtual L2AnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2GroupedOneOf(){}
        public L2GroupedOneOf(L2GroupedOneOf other) {
            Element = other.Element?.ToL2AnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2GroupedOneOf ToL2GroupedOneOf() => new L2GroupedOneOf(this);
    }
}
