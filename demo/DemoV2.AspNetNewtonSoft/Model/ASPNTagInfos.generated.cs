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
    public sealed  partial class ASPNTagInfos : IEquatable<ASPNTagInfos> {
        public const string ASPNTagInfosObjectName = "tagInfos";
        [JsonProperty("user")]
        public Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNTagInfos(){}
        public ASPNTagInfos(ASPNTagInfos other) {
            User = other.User?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNTagInfos ToASPNTagInfos() => new ASPNTagInfos(this);
        public bool Equals(ASPNTagInfos other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.User is null ? User is null : User?.SequenceEqual(other.User) ?? other.User is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNTagInfos other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNTagInfos);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(User);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
