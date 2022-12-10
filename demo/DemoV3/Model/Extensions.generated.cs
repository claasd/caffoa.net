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
            item.AgeGroup = other.AgeGroup is null ? null : (User.AgeGroupValue)other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGuestUser(this GuestUser item, GuestUser other) {
            item.Email = other.Email;
            item.Type = (GuestUser.TypeValue)other.Type;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserWithId(this UserWithId item, UserWithId other) {
            item.UpdateWithUser(other);
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithPricing(this Pricing item, Pricing other) {
            item.Price = other.Price;
            item.Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other) {
            item.Status = (LongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = other.Result?.ToAnyUser();
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTagInfos(this TagInfos item, TagInfos other) {
            item.User = other.User.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}
