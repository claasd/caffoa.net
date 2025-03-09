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
    public sealed  partial class STJTagInfos : IEquatable<STJTagInfos> {
        public const string STJTagInfosObjectName = "tagInfos";
        [JsonPropertyName("user")]
        public Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJTagInfos(){}
        public STJTagInfos(STJTagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJTagInfos ToSTJTagInfos() => new STJTagInfos(this);
        public bool Equals(STJTagInfos other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.User is null ? User is null : User?.SequenceEqual(other.User) ?? other.User is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJTagInfos other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJTagInfos);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(User);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
