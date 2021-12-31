using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class AnyCompleteUser {
        public const string AnyCompleteUserObjectName = "anyCompleteUser";


        public AnyCompleteUser ToAnyCompleteUser() {
            var item = new AnyCompleteUser();
            item.UpdateWithAnyCompleteUser(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithAnyCompleteUser(AnyCompleteUser other) {
            
        }

        /// <summary>
        /// Merges all fields of AnyCompleteUser that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAnyCompleteUser(AnyCompleteUser other, JsonMergeSettings mergeSettings = null) {
            MergeWithAnyCompleteUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of AnyCompleteUser that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAnyCompleteUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithAnyCompleteUser(sourceObject.ToObject<AnyCompleteUser>());
        }
    }
}
