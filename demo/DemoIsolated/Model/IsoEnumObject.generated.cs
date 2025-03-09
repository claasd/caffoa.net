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
    public sealed  partial class IsoEnumObject : IEquatable<IsoEnumObject> {
        public const string IsoEnumObjectObjectName = "enumObject";
        [JsonProperty("single")]
        public IsoMyEnumType Single { get; set; }

        [JsonProperty("withDefault")]
        public IsoMyEnumTypeWithDefault WithDefault { get; set; } = IsoMyEnumTypeWithDefault.Undefined;

        [JsonProperty("array")]
        public ICollection<IsoMyEnumType> Array { get; set; } = new List<IsoMyEnumType>();

        [JsonProperty("nullable")]
        public IsoMyNullableEnum? Nullable { get; set; }

        [JsonProperty("nullableReferenced")]
        public IsoNullableEnum? NullableReferenced { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoEnumObject(){}
        public IsoEnumObject(IsoEnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoEnumObject ToIsoEnumObject() => new IsoEnumObject(this);
        public bool Equals(IsoEnumObject other) {
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
        partial void _PartialEquals(IsoEnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoEnumObject);
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
