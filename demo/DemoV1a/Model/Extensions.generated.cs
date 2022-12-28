#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Error(this L1Error item, L1Error other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1User(this L1User item, L1User other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL1Address() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = other.Type;
            item.Role = other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1GuestUser(this L1GuestUser item, L1GuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1UserWithId(this L1UserWithId item, L1UserWithId other, bool deepClone = true) {
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Pricing(this L1Pricing item, L1Pricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1LongRunningfunctionStatus(this L1LongRunningfunctionStatus item, L1LongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = other.Status;
            item.Result = deepClone ? other.Result?.ToL1AnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1TagInfos(this L1TagInfos item, L1TagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1EnumObject(this L1EnumObject item, L1EnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1ExtendedAddress(this L1ExtendedAddress item, L1ExtendedAddress other, bool deepClone = true) {
            item.AddressType2 = other.AddressType2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
    }
}
