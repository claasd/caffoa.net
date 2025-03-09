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
    public sealed  partial class ASPLongRunningfunctionStatus : IEquatable<ASPLongRunningfunctionStatus> {
        public const string ASPLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonPropertyName("status")]
        public StatusValue? Status { get; set; }

        [JsonPropertyName("result")]
        public ASPAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPLongRunningfunctionStatus(){}
        public ASPLongRunningfunctionStatus(ASPLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (ASPLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToASPAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPLongRunningfunctionStatus ToASPLongRunningfunctionStatus() => new ASPLongRunningfunctionStatus(this);
        public bool Equals(ASPLongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && (Result?.Equals(other.Result) ?? other.Result is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPLongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPLongRunningfunctionStatus);
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
