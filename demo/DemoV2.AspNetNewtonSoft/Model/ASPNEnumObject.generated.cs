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
    public sealed  partial class ASPNEnumObject : IEquatable<ASPNEnumObject> {
        public const string ASPNEnumObjectObjectName = "enumObject";
        [JsonProperty("single")]
        public ASPNMyEnumType Single { get; set; }

        [JsonProperty("withDefault")]
        public ASPNMyEnumTypeWithDefault WithDefault { get; set; } = ASPNMyEnumTypeWithDefault.Undefined;

        [JsonProperty("array")]
        public ICollection<ASPNMyEnumType> Array { get; set; } = new List<ASPNMyEnumType>();

        [JsonProperty("nullable")]
        public ASPNMyNullableEnum? Nullable { get; set; }

        [JsonProperty("nullableReferenced")]
        public ASPNNullableEnum? NullableReferenced { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNEnumObject(){}
        public ASPNEnumObject(ASPNEnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNEnumObject ToASPNEnumObject() => new ASPNEnumObject(this);
        public bool Equals(ASPNEnumObject other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Single == other.Single
                && WithDefault == other.WithDefault
                && (other.Array is null ? Array is null : Array?.SequenceEqual(other.Array) ?? other.Array is null)
                && Nullable == other.Nullable
                && NullableReferenced == other.NullableReferenced;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNEnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNEnumObject);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Single);
            hashCode.Add((int) WithDefault);
            hashCode.Add(Array);
            hashCode.Add((int) Nullable);
            hashCode.Add((int) NullableReferenced);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
