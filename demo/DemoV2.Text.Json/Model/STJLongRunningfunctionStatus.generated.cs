#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public partial class STJLongRunningfunctionStatus {
        public const string STJLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonPropertyName("status")]
        public virtual StatusValue? Status { get; set; }

        [JsonPropertyName("result")]
        public virtual STJAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJLongRunningfunctionStatus(){}
        public STJLongRunningfunctionStatus(STJLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (STJLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToSTJAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJLongRunningfunctionStatus ToSTJLongRunningfunctionStatus() => new STJLongRunningfunctionStatus(this);
    }
}
