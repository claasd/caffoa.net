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
    public sealed  partial class L2GroupedOneOf : IEquatable<L2GroupedOneOf> {
        public const string L2GroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public L2AnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2GroupedOneOf(){}
        public L2GroupedOneOf(L2GroupedOneOf other) {
            Element = other.Element?.ToL2AnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2GroupedOneOf ToL2GroupedOneOf() => new L2GroupedOneOf(this);
        public bool Equals(L2GroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Element?.Equals(other.Element) ?? other.Element is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2GroupedOneOf other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2GroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
