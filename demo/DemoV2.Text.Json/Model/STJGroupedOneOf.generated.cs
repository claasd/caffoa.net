#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public partial class STJGroupedOneOf {
        public const string STJGroupedOneOfObjectName = "groupedOneOf";
        [JsonPropertyName("element")]
        public virtual STJAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJGroupedOneOf(){}
        public STJGroupedOneOf(STJGroupedOneOf other) {
            Element = other.Element?.ToSTJAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJGroupedOneOf ToSTJGroupedOneOf() => new STJGroupedOneOf(this);
    }
}
