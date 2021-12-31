using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class User : AnyUser {
        public const string UserObjectName = "user";


        public User ToUser() {
            var item = new User();
            item.UpdateWithUser(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithUser(User other) {
            
        }

        /// <summary>
        /// Merges all fields of User that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUser(User other, JsonMergeSettings mergeSettings = null) {
            MergeWithUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of User that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithUser(sourceObject.ToObject<User>());
        }
    }
}
