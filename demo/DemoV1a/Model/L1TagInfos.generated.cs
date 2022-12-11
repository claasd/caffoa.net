using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1TagInfos {
        public const string L1TagInfosObjectName = "tagInfos";

        [JsonProperty("user")]
        public virtual Dictionary<string, List<Guid>> User { get; set; } = new Dictionary<string, List<Guid>>();

        public L1TagInfos(){}
        public L1TagInfos(L1TagInfos other) {
            User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public L1TagInfos ToL1TagInfos() => new L1TagInfos(this);
    }
}
