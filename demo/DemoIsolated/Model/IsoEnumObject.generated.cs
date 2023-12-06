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
    public partial class IsoEnumObject {
        public const string IsoEnumObjectObjectName = "enumObject";
        [JsonProperty("single")]
        public virtual IsoMyEnumType Single { get; set; }

        [JsonProperty("withDefault")]
        public virtual IsoMyEnumTypeWithDefault WithDefault { get; set; } = IsoMyEnumTypeWithDefault.Undefined;

        [JsonProperty("array")]
        public virtual ICollection<IsoMyEnumType> Array { get; set; } = new List<IsoMyEnumType>();

        [JsonProperty("nullable")]
        public virtual IsoMyNullableEnum? Nullable { get; set; }

        [JsonProperty("nullableReferenced")]
        public virtual IsoNullableEnum? NullableReferenced { get; set; }

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
    }
}
