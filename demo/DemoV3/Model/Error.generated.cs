using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class Error {
        public const string ErrorObjectName = "error";


        public Error ToError() {
            var item = new Error();
            item.UpdateWithError(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithError(Error other) {
            
        }

        /// <summary>
        /// Merges all fields of Error that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithError(Error other, JsonMergeSettings mergeSettings = null) {
            MergeWithError(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of Error that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithError(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithError(sourceObject.ToObject<Error>());
        }
    }
}
