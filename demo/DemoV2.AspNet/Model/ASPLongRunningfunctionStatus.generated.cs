#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPLongRunningfunctionStatus {
        public const string ASPLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonPropertyName("status")]
        public virtual StatusValue? Status { get; set; }

        [JsonPropertyName("result")]
        public virtual ASPAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPLongRunningfunctionStatus(){}
        public ASPLongRunningfunctionStatus(ASPLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (ASPLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToASPAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPLongRunningfunctionStatus ToASPLongRunningfunctionStatus() => new ASPLongRunningfunctionStatus(this);
    }
}
