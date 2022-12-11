using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Error(this L1Error item, L1Error other) {
            item.Status = other.Status;
            item.Message = other.Message;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1User(this L1User item, L1User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL1Address();
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
        public static void UpdateWithL1GuestUser(this L1GuestUser item, L1GuestUser other) {
            item.Email = other.Email;
            item.Type = other.Type;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1UserWithId(this L1UserWithId item, L1UserWithId other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL1Address();
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
        public static void UpdateWithL1User(this L1UserWithId item, L1User other) {
            item.Name = other.Name;
            item.Address = other.Address?.ToL1Address();
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
        public static void UpdateWithL1Pricing(this L1Pricing item, L1Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1LongRunningfunctionStatus(this L1LongRunningfunctionStatus item, L1LongRunningfunctionStatus other) {
            item.Status = other.Status;
            item.Result = other.Result?.ToL1AnyUser();
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1TagInfos(this L1TagInfos item, L1TagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1EnumObject(this L1EnumObject item, L1EnumObject other) {
            item.Single = other.Single;
            item.Array = other.Array.ToList();
        }
    }
}
