#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class EnumObject {
        public const string EnumObjectObjectName = "enumObject";

        [JsonProperty("single")]
        public virtual MyEnumType Single { get; set; }

        [JsonProperty("array")]
        public virtual ICollection<MyEnumType> Array { get; set; } = new List<MyEnumType>();

        public EnumObject(){}
        public EnumObject(EnumObject other) {
            Single = other.Single;
            Array = other.Array.ToList();
        }
        public EnumObject ToEnumObject() => new EnumObject(this);
    }
}
