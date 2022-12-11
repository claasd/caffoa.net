using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1LongRunningfunctionStatus {
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
                    var allowedValues = string.Join(", ", StatusValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("status",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _status = _value;
            }
        }

        [JsonProperty("result")]
        public virtual L1AnyUser Result { get; set; }

        public L1LongRunningfunctionStatus(){}
        public L1LongRunningfunctionStatus(L1LongRunningfunctionStatus other) {
            Status = other.Status;
            Result = other.Result?.ToL1AnyUser();
        }
        public L1LongRunningfunctionStatus ToL1LongRunningfunctionStatus() => new L1LongRunningfunctionStatus(this);
    }
}
