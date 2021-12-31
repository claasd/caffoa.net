using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class AnyUser {
        public const string AnyUserObjectName = "anyUser";


        public AnyUser ToAnyUser() {
            var item = new AnyUser();
            item.UpdateWithAnyUser(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithAnyUser(AnyUser other) {
            
        }

        /// <summary>
        /// Merges all fields of AnyUser that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAnyUser(AnyUser other, JsonMergeSettings mergeSettings = null) {
            MergeWithAnyUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of AnyUser that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAnyUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithAnyUser(sourceObject.ToObject<AnyUser>());
        }
    }
}
