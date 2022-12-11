using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L2EnumObject {
        public const string L2EnumObjectObjectName = "enumObject";

        [JsonProperty("single")]
        public virtual L2MyEnumType Single { get; set; }

        [JsonProperty("array")]
        public virtual ICollection<L2MyEnumType> Array { get; set; } = new List<L2MyEnumType>();

        public L2EnumObject(){}
        public L2EnumObject(L2EnumObject other) {
            Single = other.Single;
            Array = other.Array.ToList();
        }
        public L2EnumObject ToL2EnumObject() => new L2EnumObject(this);
    }
}
