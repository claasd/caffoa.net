using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class GuestUser : AnyUser, AnyCompleteUser {
        public const string GuestUserObjectName = "guestUser";


        public GuestUser ToGuestUser() {
            var item = new GuestUser();
            item.UpdateWithGuestUser(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithGuestUser(GuestUser other) {
            
        }

        /// <summary>
        /// Merges all fields of GuestUser that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithGuestUser(GuestUser other, JsonMergeSettings mergeSettings = null) {
            MergeWithGuestUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of GuestUser that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithGuestUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithGuestUser(sourceObject.ToObject<GuestUser>());
        }
    }
}
