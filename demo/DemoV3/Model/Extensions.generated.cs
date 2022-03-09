using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithError(this Error item, Error other) {
            item.Status = other.Status;
            item.Message = other.Message;
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithError(this Error item, Error other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithError(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithError(this Error item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithError(sourceObject.ToObject<Error>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this User item, User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions;
            item.Type = other.Type;
            item.AgeGroup = other.AgeGroup;
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithUser(this User item, User other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithUser(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithUser(this User item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithUser(sourceObject.ToObject<User>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGuestUser(this GuestUser item, GuestUser other) {
            item.Email = other.Email;
            item.Type = other.Type;
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithGuestUser(this GuestUser item, GuestUser other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithGuestUser(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithGuestUser(this GuestUser item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithGuestUser(sourceObject.ToObject<GuestUser>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserWithId(this UserWithId item, UserWithId other) {
            item.UpdateWithUser(other);
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithUserWithId(this UserWithId item, UserWithId other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithUserWithId(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithUserWithId(this UserWithId item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithUserWithId(sourceObject.ToObject<UserWithId>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithPricing(this Pricing item, Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes;
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithPricing(this Pricing item, Pricing other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithPricing(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithPricing(this Pricing item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithPricing(sourceObject.ToObject<Pricing>());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other) {
            item.Status = other.Status;
            item.Result = other.Result?.ToAnyUser();
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other, JsonMergeSettings mergeSettings = null) {
            item.MergeWithLongRunningfunctionStatus(JObject.FromObject(other), mergeSettings);
        }

        [Obsolete("Use MergedWith<T> from CdIts.Caffoa.Extensions instead")]
        public static void MergeWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWithLongRunningfunctionStatus(sourceObject.ToObject<LongRunningfunctionStatus>());
        }
    }
}
