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
    public sealed  partial class EnumObject : IEquatable<EnumObject> {
        public const string EnumObjectObjectName = "enumObject";
        [JsonProperty("single")]
        public MyEnumType Single { get; set; }

        [JsonProperty("withDefault")]
        public MyEnumTypeWithDefault WithDefault { get; set; } = MyEnumTypeWithDefault.Undefined;

        [JsonProperty("array")]
        public ICollection<MyEnumType> Array { get; set; } = new List<MyEnumType>();

        [JsonProperty("nullable")]
        public MyNullableEnum? Nullable { get; set; }

        [JsonProperty("nullableReferenced")]
        public NullableEnum? NullableReferenced { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public EnumObject(){}
        public EnumObject(EnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public EnumObject ToEnumObject() => new EnumObject(this);
        public bool Equals(EnumObject other) {
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
        partial void _PartialEquals(EnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as EnumObject);
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
