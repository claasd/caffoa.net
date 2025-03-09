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
    public sealed  partial class IsoGroupedOneOf : IEquatable<IsoGroupedOneOf> {
        public const string IsoGroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public IsoAnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoGroupedOneOf(){}
        public IsoGroupedOneOf(IsoGroupedOneOf other) {
            Element = other.Element?.ToIsoAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoGroupedOneOf ToIsoGroupedOneOf() => new IsoGroupedOneOf(this);
        public bool Equals(IsoGroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Element?.Equals(other.Element) ?? other.Element is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IsoGroupedOneOf other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoGroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
