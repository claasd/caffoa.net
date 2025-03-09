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
    public sealed  partial class STJEnumObject : IEquatable<STJEnumObject> {
        public const string STJEnumObjectObjectName = "enumObject";
        [JsonPropertyName("single")]
        public STJMyEnumType Single { get; set; }

        [JsonPropertyName("withDefault")]
        public STJMyEnumTypeWithDefault WithDefault { get; set; } = STJMyEnumTypeWithDefault.Undefined;

        [JsonPropertyName("array")]
        public ICollection<STJMyEnumType> Array { get; set; } = new List<STJMyEnumType>();

        [JsonPropertyName("nullable")]
        public STJMyNullableEnum? Nullable { get; set; }

        [JsonPropertyName("nullableReferenced")]
        public STJNullableEnum? NullableReferenced { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJEnumObject(){}
        public STJEnumObject(STJEnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJEnumObject ToSTJEnumObject() => new STJEnumObject(this);
        public bool Equals(STJEnumObject other) {
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
        partial void _PartialEquals(STJEnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJEnumObject);
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
