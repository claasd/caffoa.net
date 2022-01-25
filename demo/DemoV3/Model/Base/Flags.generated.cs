using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV3.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Flags {
        public const string FlagsObjectName = "flags";

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("desc")]
        public virtual string Desc { get; set; }

        public Flags ToFlags() {
            var item = new Flags();
            item.UpdateWithFlags(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithFlags(Flags other) {
            Id = other.Id;
            Desc = other.Desc;
        }

        /// <summary>
        /// Merges all fields of Flags that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithFlags(Flags other, JsonMergeSettings mergeSettings = null) {
            MergeWithFlags(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of Flags that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithFlags(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithFlags(sourceObject.ToObject<Flags>());
        }
    }
}
