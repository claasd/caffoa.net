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
    public sealed  partial class STJGroupedOneOf : IEquatable<STJGroupedOneOf> {
        public const string STJGroupedOneOfObjectName = "groupedOneOf";
        [JsonPropertyName("element")]
        public STJAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJGroupedOneOf(){}
        public STJGroupedOneOf(STJGroupedOneOf other) {
            Element = other.Element?.ToSTJAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJGroupedOneOf ToSTJGroupedOneOf() => new STJGroupedOneOf(this);
        public bool Equals(STJGroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Element?.Equals(other.Element) ?? other.Element is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJGroupedOneOf other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJGroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
