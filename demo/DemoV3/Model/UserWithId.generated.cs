using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class UserWithId : User, AnyCompleteUser {
        public const string UserWithIdObjectName = "userWithId";


        public UserWithId ToUserWithId() {
            var item = new UserWithId();
            item.UpdateWithUserWithId(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithUserWithId(UserWithId other) {
            
        }

        /// <summary>
        /// Merges all fields of UserWithId that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUserWithId(UserWithId other, JsonMergeSettings mergeSettings = null) {
            MergeWithUserWithId(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of UserWithId that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUserWithId(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithUserWithId(sourceObject.ToObject<UserWithId>());
        }
    }
}
