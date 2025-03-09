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
    public sealed  partial class IsoLongRunningfunctionStatus : IEquatable<IsoLongRunningfunctionStatus> {
        public const string IsoLongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("result")]
        public IsoAnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoLongRunningfunctionStatus(){}
        public IsoLongRunningfunctionStatus(IsoLongRunningfunctionStatus other) {
            Status = other.Status == null ? null : (IsoLongRunningfunctionStatus.StatusValue)other.Status;
            Result = other.Result?.ToIsoAnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoLongRunningfunctionStatus ToIsoLongRunningfunctionStatus() => new IsoLongRunningfunctionStatus(this);
        public bool Equals(IsoLongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && (Result?.Equals(other.Result) ?? other.Result is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IsoLongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoLongRunningfunctionStatus);
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
