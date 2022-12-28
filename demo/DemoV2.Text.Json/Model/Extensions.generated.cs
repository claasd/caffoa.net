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
        /// Returns a new object of STJError with fileds filled from STJError. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJError ToSTJError(this STJError other, bool deepClone = true) => new STJError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of STJUser with fileds filled from STJUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJUser ToSTJUser(this STJUser other, bool deepClone = true) => new STJUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToSTJAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (STJUser.TypeValue)other.Type,
            Role = (STJUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJGuestUser(this STJGuestUser item, STJGuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (STJGuestUser.TypeValue)other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJGuestUser with fileds filled from STJGuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJGuestUser ToSTJGuestUser(this STJGuestUser other, bool deepClone = true) => new STJGuestUser() { 
            Email = other.Email,
            Type = (STJGuestUser.TypeValue)other.Type,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of STJUserWithId with fileds filled from STJUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJUserWithId ToSTJUserWithId(this STJUserWithId other, bool deepClone = true) => new STJUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToSTJAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (STJUserWithId.TypeValue)other.Type,
            Role = (STJUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.Clone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of STJUserWithId with fileds filled from STJUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJUserWithId ToSTJUserWithId(this STJUser other, bool deepClone = true) => new STJUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToSTJAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (STJUserWithId.TypeValue)other.Type,
            Role = (STJUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of STJUser with fileds filled from STJUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJUser ToSTJUser(this STJUserWithId other, bool deepClone = true) => new STJUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToSTJAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (STJUser.TypeValue)other.Type,
            Role = (STJUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJPricing(this STJPricing item, STJPricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJPricing with fileds filled from STJPricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJPricing ToSTJPricing(this STJPricing other, bool deepClone = true) => new STJPricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJLongRunningfunctionStatus(this STJLongRunningfunctionStatus item, STJLongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = (STJLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToSTJAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJLongRunningfunctionStatus with fileds filled from STJLongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJLongRunningfunctionStatus ToSTJLongRunningfunctionStatus(this STJLongRunningfunctionStatus other, bool deepClone = true) => new STJLongRunningfunctionStatus() { 
            Status = (STJLongRunningfunctionStatus.StatusValue)other.Status,
            Result = deepClone ? other.Result?.ToSTJAnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJTagInfos(this STJTagInfos item, STJTagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJTagInfos with fileds filled from STJTagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJTagInfos ToSTJTagInfos(this STJTagInfos other, bool deepClone = true) => new STJTagInfos() { 
            User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJEnumObject(this STJEnumObject item, STJEnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJEnumObject with fileds filled from STJEnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJEnumObject ToSTJEnumObject(this STJEnumObject other, bool deepClone = true) => new STJEnumObject() { 
            Single = other.Single,
            Array = deepClone ? other.Array.ToList() : other.Array,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of STJExtendedAddress with fileds filled from STJExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJExtendedAddress ToSTJExtendedAddress(this STJExtendedAddress other, bool deepClone = true) => new STJExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags,
            AddressType2 = other.AddressType2
        };

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
        /// Returns a new object of STJExtendedAddress with fileds filled from STJAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJExtendedAddress ToSTJExtendedAddress(this STJAddress other, bool deepClone = true) => new STJExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (STJExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags
        };

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
        
        /// <summary>
        /// Returns a new object of STJAddress with fileds filled from STJExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJAddress ToSTJAddress(this STJExtendedAddress other, bool deepClone = true) => new STJAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (STJAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToSTJFlags()) : other.Flags
        };
    }
}
