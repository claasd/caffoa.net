#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public partial class LongRunningfunctionStatus {
        public const string LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";

        [JsonProperty("status")]
        public virtual StatusValue Status { get; set; }

        [JsonProperty("result")]
        public virtual AnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public LongRunningfunctionStatus(){}
        public LongRunningfunctionStatus(LongRunningfunctionStatus other) {
            Status = (LongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public LongRunningfunctionStatus ToLongRunningfunctionStatus() => new LongRunningfunctionStatus(this);
    }
}
