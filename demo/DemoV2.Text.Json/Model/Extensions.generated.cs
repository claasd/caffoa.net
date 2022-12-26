#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJError(this STJError item, STJError other) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUser(this STJUser item, STJUser other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToSTJAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (STJUser.TypeValue)other.Type;
            item.Role = (STJUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJGuestUser(this STJGuestUser item, STJGuestUser other) {
            item.Email = other.Email;
            item.Type = (STJGuestUser.TypeValue)other.Type;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUserWithId(this STJUserWithId item, STJUserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToSTJAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (STJUserWithId.TypeValue)other.Type;
            item.Role = (STJUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = other.Diffs;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUserWithId(this STJUser item, STJUserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToSTJAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (STJUser.TypeValue)other.Type;
            item.Role = (STJUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJUser(this STJUserWithId item, STJUser other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToSTJAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (STJUserWithId.TypeValue)other.Type;
            item.Role = (STJUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJPricing(this STJPricing item, STJPricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJLongRunningfunctionStatus(this STJLongRunningfunctionStatus item, STJLongRunningfunctionStatus other) {
            item.Status = (STJLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = other.Result?.ToSTJAnyUser();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJTagInfos(this STJTagInfos item, STJTagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJEnumObject(this STJEnumObject item, STJEnumObject other) {
            item.Single = other.Single;
            item.Array = other.Array.ToList();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJExtendedAddress(this STJExtendedAddress item, STJExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags());
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJExtendedAddress(this STJAddress item, STJExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJAddress.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJAddress(this STJExtendedAddress item, STJAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags());
        }
    }
}
