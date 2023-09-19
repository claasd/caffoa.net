#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNLongRunningfunctionStatus {
        public const string ASPNLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonProperty("status")]
        public virtual StatusValue Status { get; set; }

        [JsonProperty("result")]
        public virtual ASPNAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNLongRunningfunctionStatus(){}
        public ASPNLongRunningfunctionStatus(ASPNLongRunningfunctionStatus other) {
            Status = (ASPNLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToASPNAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNLongRunningfunctionStatus ToASPNLongRunningfunctionStatus() => new ASPNLongRunningfunctionStatus(this);
    }
}
