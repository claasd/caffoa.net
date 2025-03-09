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
    public sealed  partial class ASPEnumObject : IEquatable<ASPEnumObject> {
        public const string ASPEnumObjectObjectName = "enumObject";
        [JsonPropertyName("single")]
        public ASPMyEnumType Single { get; set; }

        [JsonPropertyName("withDefault")]
        public ASPMyEnumTypeWithDefault WithDefault { get; set; } = ASPMyEnumTypeWithDefault.Undefined;

        [JsonPropertyName("array")]
        public ICollection<ASPMyEnumType> Array { get; set; } = new List<ASPMyEnumType>();

        [JsonPropertyName("nullable")]
        public ASPMyNullableEnum? Nullable { get; set; }

        [JsonPropertyName("nullableReferenced")]
        public ASPNullableEnum? NullableReferenced { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPEnumObject(){}
        public ASPEnumObject(ASPEnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPEnumObject ToASPEnumObject() => new ASPEnumObject(this);
        public bool Equals(ASPEnumObject other) {
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
        partial void _PartialEquals(ASPEnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPEnumObject);
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
