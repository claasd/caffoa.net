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
    public partial class TagInfos {
        public const string TagInfosObjectName = "tagInfos";

        [JsonProperty("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        public TagInfos(){}
        public TagInfos(TagInfos other) {
            User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public TagInfos ToTagInfos() => new TagInfos(this);
    }
}
