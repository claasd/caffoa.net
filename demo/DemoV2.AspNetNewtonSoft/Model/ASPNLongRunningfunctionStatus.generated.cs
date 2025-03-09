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
    public sealed  partial class ASPNLongRunningfunctionStatus : IEquatable<ASPNLongRunningfunctionStatus> {
        public const string ASPNLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("result")]
        public ASPNAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNLongRunningfunctionStatus(){}
        public ASPNLongRunningfunctionStatus(ASPNLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (ASPNLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToASPNAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNLongRunningfunctionStatus ToASPNLongRunningfunctionStatus() => new ASPNLongRunningfunctionStatus(this);
        public bool Equals(ASPNLongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && (Result?.Equals(other.Result) ?? other.Result is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNLongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNLongRunningfunctionStatus);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Status);
            hashCode.Add(Result);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
