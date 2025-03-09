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
    public sealed  partial class ASPNGroupedOneOf : IEquatable<ASPNGroupedOneOf> {
        public const string ASPNGroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public ASPNAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNGroupedOneOf(){}
        public ASPNGroupedOneOf(ASPNGroupedOneOf other) {
            Element = other.Element?.ToASPNAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNGroupedOneOf ToASPNGroupedOneOf() => new ASPNGroupedOneOf(this);
        public bool Equals(ASPNGroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Element?.Equals(other.Element) ?? other.Element is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNGroupedOneOf other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNGroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
