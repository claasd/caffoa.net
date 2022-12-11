using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Error(this L2Error item, L2Error other) {
            item.Status = other.Status;
            item.Message = other.Message;
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
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2GuestUser(this L2GuestUser item, L2GuestUser other) {
            item.Email = other.Email;
            item.Type = other.Type;
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
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
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
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Pricing(this L2Pricing item, L2Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2LongRunningfunctionStatus(this L2LongRunningfunctionStatus item, L2LongRunningfunctionStatus other) {
            item.Status = other.Status;
            item.Result = other.Result?.ToL2AnyUser();
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2TagInfos(this L2TagInfos item, L2TagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2EnumObject(this L2EnumObject item, L2EnumObject other) {
            item.Single = other.Single;
            item.Array = other.Array.ToList();
        }
    }
}
