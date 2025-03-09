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
    public sealed  partial class ASPGroupedOneOf : IEquatable<ASPGroupedOneOf> {
        public const string ASPGroupedOneOfObjectName = "groupedOneOf";
        [JsonPropertyName("element")]
        public ASPAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPGroupedOneOf(){}
        public ASPGroupedOneOf(ASPGroupedOneOf other) {
            Element = other.Element?.ToASPAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPGroupedOneOf ToASPGroupedOneOf() => new ASPGroupedOneOf(this);
        public bool Equals(ASPGroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Element?.Equals(other.Element) ?? other.Element is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPGroupedOneOf other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPGroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
