#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Error(this L2Error item, L2Error other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2User(this L2User item, L2User other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL2Address() : other.Address;
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
        public static void UpdateWithL2GuestUser(this L2GuestUser item, L2GuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2UserWithId(this L2UserWithId item, L2UserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL2Address() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = other.Type;
            item.Role = other.Role;
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
        public static void UpdateWithL2UserWithId(this L2User item, L2UserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL2Address() : other.Address;
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
        public static void UpdateWithL2User(this L2UserWithId item, L2User other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL2Address() : other.Address;
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
        public static void UpdateWithL2Pricing(this L2Pricing item, L2Pricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2LongRunningfunctionStatus(this L2LongRunningfunctionStatus item, L2LongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = other.Status;
            item.Result = deepClone ? other.Result?.ToL2AnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2TagInfos(this L2TagInfos item, L2TagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2EnumObject(this L2EnumObject item, L2EnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2ExtendedAddress(this L2ExtendedAddress item, L2ExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2ExtendedAddress(this L2Address item, L2ExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags()) : other.Flags;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Address(this L2ExtendedAddress item, L2Address other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags()) : other.Flags;
        }
    }
}
