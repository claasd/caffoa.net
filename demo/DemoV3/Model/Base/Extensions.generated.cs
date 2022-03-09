using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV3.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFlags(this Flags item, Flags other) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWithFlags(this Flags item, Flags other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithFlags(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWithFlags(this Flags item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithFlags(sourceObject.ToObject<Flags>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithAddress(this Address item, Address other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.Flags = other.Flags;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWithAddress(this Address item, Address other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithAddress(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWithAddress(this Address item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithAddress(sourceObject.ToObject<Address>());
        }
    }
}
