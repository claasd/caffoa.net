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
    public partial class ASPEnumObject {
        public const string ASPEnumObjectObjectName = "enumObject";
        [JsonPropertyName("single")]
        public virtual ASPMyEnumType Single { get; set; }

        [JsonPropertyName("withDefault")]
        public virtual ASPMyEnumTypeWithDefault WithDefault { get; set; } = ASPMyEnumTypeWithDefault.Undefined;

        [JsonPropertyName("array")]
        public virtual ICollection<ASPMyEnumType> Array { get; set; } = new List<ASPMyEnumType>();

        [JsonPropertyName("nullable")]
        public virtual ASPMyNullableEnum? Nullable { get; set; }

        [JsonPropertyName("nullableReferenced")]
        public virtual ASPNullableEnum? NullableReferenced { get; set; }

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
    }
}
