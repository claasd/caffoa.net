#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJError(this STJError item, STJError other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUser(this STJUser item, STJUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToSTJAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (STJUser.TypeValue)other.Type;
            item.Role = (STJUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJGuestUser(this STJGuestUser item, STJGuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (STJGuestUser.TypeValue)other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUserWithId(this STJUserWithId item, STJUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToSTJAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (STJUserWithId.TypeValue)other.Type;
            item.Role = (STJUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.Clone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUserWithId(this STJUser item, STJUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToSTJAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (STJUser.TypeValue)other.Type;
            item.Role = (STJUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUser(this STJUserWithId item, STJUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToSTJAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (STJUserWithId.TypeValue)other.Type;
            item.Role = (STJUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJPricing(this STJPricing item, STJPricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJLongRunningfunctionStatus(this STJLongRunningfunctionStatus item, STJLongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = (STJLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToSTJAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJTagInfos(this STJTagInfos item, STJTagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJEnumObject(this STJEnumObject item, STJEnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJExtendedAddress(this STJExtendedAddress item, STJExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJExtendedAddress(this STJAddress item, STJExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJAddress(this STJExtendedAddress item, STJAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags;
        }
    }
}
