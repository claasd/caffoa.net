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

        public LongRunningfunctionStatus ToLongRunningfunctionStatus() {
            var item = new LongRunningfunctionStatus();
            item.UpdateWithLongRunningfunctionStatus(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithLongRunningfunctionStatus(LongRunningfunctionStatus other) {
            Status = other.Status;
            Result = other.Result?.ToAnyUser();
        }

        /// <summary>
        /// Merges all fields of LongRunningfunctionStatus that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithLongRunningfunctionStatus(LongRunningfunctionStatus other, JsonMergeSettings mergeSettings = null) {
            MergeWithLongRunningfunctionStatus(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of LongRunningfunctionStatus that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithLongRunningfunctionStatus(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithLongRunningfunctionStatus(sourceObject.ToObject<LongRunningfunctionStatus>());
        }
    }
}
