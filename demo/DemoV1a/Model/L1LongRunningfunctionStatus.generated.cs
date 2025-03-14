#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1LongRunningfunctionStatus : IEquatable<L1LongRunningfunctionStatus> {
        public const string L1LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
        [JsonIgnore]
        private string _status;

        [JsonProperty("status")]
        public virtual string Status {
            get => _status;
            set {
                var _value = StatusValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                if (!StatusValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", StatusValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("status",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _status = _value;
            }
        }

        [JsonProperty("result")]
        public virtual L1AnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1LongRunningfunctionStatus(){}
        public L1LongRunningfunctionStatus(L1LongRunningfunctionStatus other) {
            Status = other.Status;
            Result = other.Result?.ToL1AnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1LongRunningfunctionStatus ToL1LongRunningfunctionStatus() => new L1LongRunningfunctionStatus(this);
        public bool Equals(L1LongRunningfunctionStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && (Result?.Equals(other.Result) ?? other.Result is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1LongRunningfunctionStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1LongRunningfunctionStatus);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Status);
            hashCode.Add(Result);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
