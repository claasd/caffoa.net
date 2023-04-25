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
    public partial class STJEnumObject {
        public const string STJEnumObjectObjectName = "enumObject";
        [JsonPropertyName("single")]
        public virtual STJMyEnumType Single { get; set; }

        [JsonPropertyName("withDefault")]
        public virtual STJMyEnumTypeWithDefault WithDefault { get; set; } = STJMyEnumTypeWithDefault.Undefined;

        [JsonPropertyName("array")]
        public virtual ICollection<STJMyEnumType> Array { get; set; } = new List<STJMyEnumType>();

        [JsonPropertyName("nullable")]
        public virtual STJMyNullableEnum? Nullable { get; set; }

        [JsonPropertyName("nullableReferenced")]
        public virtual STJNullableEnum? NullableReferenced { get; set; }

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
    }
}
