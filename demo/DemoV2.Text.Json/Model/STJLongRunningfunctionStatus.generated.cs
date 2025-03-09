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
    public sealed  partial class STJLongRunningfunctionStatus : IEquatable<STJLongRunningfunctionStatus> {
        public const string STJLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonPropertyName("status")]
        public StatusValue? Status { get; set; }

        [JsonPropertyName("result")]
        public STJAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJLongRunningfunctionStatus(){}
        public STJLongRunningfunctionStatus(STJLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (STJLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToSTJAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJLongRunningfunctionStatus ToSTJLongRunningfunctionStatus() => new STJLongRunningfunctionStatus(this);
        public bool Equals(STJLongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && (Result?.Equals(other.Result) ?? other.Result is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJLongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJLongRunningfunctionStatus);
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
