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
        /// Returns a new object of Error with fileds filled from Error. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Error ToError(this Error other, bool deepClone = true) => new Error() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of User with fileds filled from User. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static User ToUser(this User other, bool deepClone = true) => new User() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (User.TypeValue)other.Type,
            Role = (User.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGuestUser(this GuestUser item, GuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (GuestUser.TypeValue)other.Type;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of GuestUser with fileds filled from GuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static GuestUser ToGuestUser(this GuestUser other, bool deepClone = true) => new GuestUser() { 
            Email = other.Email,
            Type = (GuestUser.TypeValue)other.Type,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of UserWithId with fileds filled from UserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static UserWithId ToUserWithId(this UserWithId other, bool deepClone = true) => new UserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (UserWithId.TypeValue)other.Type,
            Role = (UserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of UserWithId with fileds filled from User. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static UserWithId ToUserWithId(this User other, bool deepClone = true) => new UserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (UserWithId.TypeValue)other.Type,
            Role = (UserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of User with fileds filled from UserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static User ToUser(this UserWithId other, bool deepClone = true) => new User() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (User.TypeValue)other.Type,
            Role = (User.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithPricing(this Pricing item, Pricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of Pricing with fileds filled from Pricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Pricing ToPricing(this Pricing other, bool deepClone = true) => new Pricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLongRunningfunctionStatus(this LongRunningfunctionStatus item, LongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = (LongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of LongRunningfunctionStatus with fileds filled from LongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static LongRunningfunctionStatus ToLongRunningfunctionStatus(this LongRunningfunctionStatus other, bool deepClone = true) => new LongRunningfunctionStatus() { 
            Status = (LongRunningfunctionStatus.StatusValue)other.Status,
            Result = deepClone ? other.Result?.ToAnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTagInfos(this TagInfos item, TagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of TagInfos with fileds filled from TagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TagInfos ToTagInfos(this TagInfos other, bool deepClone = true) => new TagInfos() { 
            User = deepClone ? other.User.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithEnumObject(this EnumObject item, EnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.Array = deepClone ? other.Array.ToList() : other.Array;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of EnumObject with fileds filled from EnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static EnumObject ToEnumObject(this EnumObject other, bool deepClone = true) => new EnumObject() { 
            Single = other.Single,
            Array = deepClone ? other.Array.ToList() : other.Array,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };

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
        /// Returns a new object of ExtendedAddress with fileds filled from ExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExtendedAddress ToExtendedAddress(this ExtendedAddress other, bool deepClone = true) => new ExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags,
            AddressType2 = other.AddressType2
        };

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
        /// Returns a new object of ExtendedAddress with fileds filled from Address. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExtendedAddress ToExtendedAddress(this Address other, bool deepClone = true) => new ExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags
        };

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
        
        /// <summary>
        /// Returns a new object of Address with fileds filled from ExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Address ToAddress(this ExtendedAddress other, bool deepClone = true) => new Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (Address.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToFlags()) : other.Flags
        };
    }
}
