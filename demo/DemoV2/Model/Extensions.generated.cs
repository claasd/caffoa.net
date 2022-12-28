#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DemoV2.Model.Base;

namespace DemoV2.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithError(this Error item, Error other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this User item, User other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (User.TypeValue)other.Type;
            item.Role = (User.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGuestUser(this GuestUser item, GuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (GuestUser.TypeValue)other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserWithId(this UserWithId item, UserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (UserWithId.TypeValue)other.Type;
            item.Role = (UserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserWithId(this User item, UserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (User.TypeValue)other.Type;
            item.Role = (User.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this UserWithId item, User other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (UserWithId.TypeValue)other.Type;
            item.Role = (UserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithPricing(this Pricing item, Pricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = (LongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTagInfos(this TagInfos item, TagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithEnumObject(this EnumObject item, EnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExtendedAddress(this ExtendedAddress item, ExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExtendedAddress(this Address item, ExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (Address.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithAddress(this ExtendedAddress item, Address other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags;
        }
    }
}
