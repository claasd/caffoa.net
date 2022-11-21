using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LongRunningfunctionStatus {
        public const string LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";

        [JsonProperty("status")]
        public virtual StatusValue Status { get; set; }

        [JsonProperty("result")]
        public virtual AnyUser Result { get; set; }

        public LongRunningfunctionStatus(){}
        public LongRunningfunctionStatus(LongRunningfunctionStatus other) {
            Status = (StatusValue)other.Status;
            Result = other.Result?.ToAnyUser();
        }
        public LongRunningfunctionStatus ToLongRunningfunctionStatus() => new LongRunningfunctionStatus(this);
    }
}
