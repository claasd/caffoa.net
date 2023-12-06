#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public partial class IsoLongRunningfunctionStatus {
        public const string IsoLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonProperty("status")]
        public virtual StatusValue Status { get; set; }

        [JsonProperty("result")]
        public virtual IsoAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoLongRunningfunctionStatus(){}
        public IsoLongRunningfunctionStatus(IsoLongRunningfunctionStatus other) {
            Status = (IsoLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToIsoAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoLongRunningfunctionStatus ToIsoLongRunningfunctionStatus() => new IsoLongRunningfunctionStatus(this);
    }
}
