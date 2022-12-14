#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1EnumObject {
        public const string L1EnumObjectObjectName = "enumObject";

        [JsonProperty("single")]
        public virtual L1MyEnumType Single { get; set; }

        [JsonProperty("array")]
        public virtual ICollection<L1MyEnumType> Array { get; set; } = new List<L1MyEnumType>();

        public L1EnumObject(){}
        public L1EnumObject(L1EnumObject other) {
            Single = other.Single;
            Array = other.Array.ToList();
        }
        public L1EnumObject ToL1EnumObject() => new L1EnumObject(this);
    }
}
