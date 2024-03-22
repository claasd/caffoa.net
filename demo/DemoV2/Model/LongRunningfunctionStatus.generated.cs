#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class LongRunningfunctionStatus : IEquatable<LongRunningfunctionStatus> {
        public const string LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("result")]
        public AnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public LongRunningfunctionStatus(){}
        public LongRunningfunctionStatus(LongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (LongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public LongRunningfunctionStatus ToLongRunningfunctionStatus() => new LongRunningfunctionStatus(this);
        public bool Equals(LongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status && Result.Equals(other.Result);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(LongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as LongRunningfunctionStatus);
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
