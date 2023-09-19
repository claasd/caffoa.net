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
    public partial class ASPNEnumObject {
        public const string ASPNEnumObjectObjectName = "enumObject";
        [JsonProperty("single")]
        public virtual ASPNMyEnumType Single { get; set; }

        [JsonProperty("withDefault")]
        public virtual ASPNMyEnumTypeWithDefault WithDefault { get; set; } = ASPNMyEnumTypeWithDefault.Undefined;

        [JsonProperty("array")]
        public virtual ICollection<ASPNMyEnumType> Array { get; set; } = new List<ASPNMyEnumType>();

        [JsonProperty("nullable")]
        public virtual ASPNMyNullableEnum? Nullable { get; set; }

        [JsonProperty("nullableReferenced")]
        public virtual ASPNNullableEnum? NullableReferenced { get; set; }

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
    }
}
