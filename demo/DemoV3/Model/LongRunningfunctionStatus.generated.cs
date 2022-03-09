using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class LongRunningfunctionStatus {
        public const string LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";

        [JsonIgnore]
        private string _status;

        [JsonProperty("status")]
        public virtual string Status {
            get => _status;
            set {
                if (!StatusValues.AllowedValues.Contains(value))
                {
                    var allowedValues = string.Join(", ", StatusValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("status",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _status = value;
            }
        }

        [JsonProperty("result")]
        public virtual AnyUser Result { get; set; }

        public LongRunningfunctionStatus(){}
        public LongRunningfunctionStatus(LongRunningfunctionStatus other) {
            Status = other.Status;
            Result = other.Result?.ToAnyUser();
        }
        public LongRunningfunctionStatus ToLongRunningfunctionStatus() => new LongRunningfunctionStatus(this);
    }
}
