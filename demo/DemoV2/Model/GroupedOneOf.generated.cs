#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public partial class GroupedOneOf : IEquatable<GroupedOneOf> {
        public const string GroupedOneOfObjectName = "groupedOneOf";
        [JsonProperty("element")]
        public virtual AnyUser Element { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public GroupedOneOf(){}
        public GroupedOneOf(GroupedOneOf other) {
            Element = other.Element?.ToAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public GroupedOneOf ToGroupedOneOf() => new GroupedOneOf(this);
        public bool Equals(GroupedOneOf other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Element.Equals(other.Element);
        }
        public override bool Equals(object obj) => Equals(obj as GroupedOneOf);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Element);
            return hashCode.ToHashCode();
        }
    }
}
