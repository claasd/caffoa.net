#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using DemoV2.Model.Base;

namespace DemoV2.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithError(this Error item, Error other) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this User item, User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (User.TypeValue)other.Type;
            item.Role = (User.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGuestUser(this GuestUser item, GuestUser other) {
            item.Email = other.Email;
            item.Type = (GuestUser.TypeValue)other.Type;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserWithId(this UserWithId item, UserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (UserWithId.TypeValue)other.Type;
            item.Role = (UserWithId.RoleValue)other.Role;
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
        public static void UpdateWithUserWithId(this User item, UserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (User.TypeValue)other.Type;
            item.Role = (User.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this UserWithId item, User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToAddress();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = (UserWithId.TypeValue)other.Type;
            item.Role = (UserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithPricing(this Pricing item, Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other) {
            item.Status = (LongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = other.Result?.ToAnyUser();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTagInfos(this TagInfos item, TagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithEnumObject(this EnumObject item, EnumObject other) {
            item.Single = other.Single;
            item.Array = other.Array.ToList();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExtendedAddress(this ExtendedAddress item, ExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags());
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExtendedAddress(this Address item, ExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (Address.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithAddress(this ExtendedAddress item, Address other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags());
        }
    }
}
