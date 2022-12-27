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
    public partial class EnumObject {
        public const string EnumObjectObjectName = "enumObject";

        [JsonProperty("single")]
        public virtual MyEnumType Single { get; set; }

        [JsonProperty("array")]
        public virtual ICollection<MyEnumType> Array { get; set; } = new List<MyEnumType>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public EnumObject(){}
        public EnumObject(EnumObject other) {
            Single = other.Single;
            Array = other.Array.ToList();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public EnumObject ToEnumObject() => new EnumObject(this);
    }
}
