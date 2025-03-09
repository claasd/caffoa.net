#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1TagInfos : IEquatable<L1TagInfos> {
        public const string L1TagInfosObjectName = "tagInfos";
        [JsonProperty("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1TagInfos(){}
        public L1TagInfos(L1TagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1TagInfos ToL1TagInfos() => new L1TagInfos(this);
        public bool Equals(L1TagInfos other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.User is null ? User is null : User?.SequenceEqual(other.User) ?? other.User is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1TagInfos other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1TagInfos);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(User);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
