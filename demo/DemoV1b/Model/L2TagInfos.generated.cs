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
    public sealed  partial class L2TagInfos : IEquatable<L2TagInfos> {
        public const string L2TagInfosObjectName = "tagInfos";
        [JsonProperty("user")]
        public Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2TagInfos(){}
        public L2TagInfos(L2TagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2TagInfos ToL2TagInfos() => new L2TagInfos(this);
        public bool Equals(L2TagInfos other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.User is null ? User is null : User?.SequenceEqual(other.User) ?? other.User is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2TagInfos other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2TagInfos);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(User);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
