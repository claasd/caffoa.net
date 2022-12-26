#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Error(this L2Error item, L2Error other) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2User(this L2User item, L2User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL2Address();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = other.Type;
            item.Role = other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2GuestUser(this L2GuestUser item, L2GuestUser other) {
            item.Email = other.Email;
            item.Type = other.Type;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2UserWithId(this L2UserWithId item, L2UserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL2Address();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = other.Type;
            item.Role = other.Role;
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
        public static void UpdateWithL2UserWithId(this L2User item, L2UserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL2Address();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = other.Type;
            item.Role = other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2User(this L2UserWithId item, L2User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL2Address();
            item.Birthdate = other.Birthdate;
            item.Emails = other.Emails.ToList();
            item.Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.Type = other.Type;
            item.Role = other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Pricing(this L2Pricing item, L2Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2LongRunningfunctionStatus(this L2LongRunningfunctionStatus item, L2LongRunningfunctionStatus other) {
            item.Status = other.Status;
            item.Result = other.Result?.ToL2AnyUser();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2TagInfos(this L2TagInfos item, L2TagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2EnumObject(this L2EnumObject item, L2EnumObject other) {
            item.Single = other.Single;
            item.Array = other.Array.ToList();
            item.AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2ExtendedAddress(this L2ExtendedAddress item, L2ExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
            item.AddressType2 = other.AddressType2;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2ExtendedAddress(this L2Address item, L2ExtendedAddress other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Address(this L2ExtendedAddress item, L2Address other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
        }
    }
}
