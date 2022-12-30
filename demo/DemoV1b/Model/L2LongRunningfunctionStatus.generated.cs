#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2LongRunningfunctionStatus {
        public const string L2LongRunningfunctionStatusObjectName = "longRunningfunctionStatus";
            [JsonIgnore]
            private string _status;
    
            [JsonProperty("status")]
            public virtual string Status {
                get => _status;
                set {
                    var _value = StatusValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                    // set checkEnums=true in config file to have a value check here //
                // if (!StatusValues.AllowedValues.Contains(_value))
                    // {
                    //     var allowedValues = string.Join(", ", StatusValues.AllowedValues.Select(v => v.ToString()));
                    //     throw new ArgumentOutOfRangeException("status",
                    //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                    // }
                    _status = _value;
                }
            }

        [JsonProperty("result")]
        public virtual L2AnyUser Result { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2LongRunningfunctionStatus(){}
        public L2LongRunningfunctionStatus(L2LongRunningfunctionStatus other) {
            Status = other.Status;
            Result = other.Result?.ToL2AnyUser();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2LongRunningfunctionStatus ToL2LongRunningfunctionStatus() => new L2LongRunningfunctionStatus(this);
    }
}
