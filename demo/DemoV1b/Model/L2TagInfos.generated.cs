using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L2TagInfos {
        public const string L2TagInfosObjectName = "tagInfos";

        [JsonProperty("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        public L2TagInfos(){}
        public L2TagInfos(L2TagInfos other) {
            User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public L2TagInfos ToL2TagInfos() => new L2TagInfos(this);
    }
}
