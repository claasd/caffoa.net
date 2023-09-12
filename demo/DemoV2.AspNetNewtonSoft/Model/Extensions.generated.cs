#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNError(this ASPNError item, ASPNError other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNError with fileds filled from ASPNError. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNError ToASPNError(this ASPNError other, bool deepClone = true) => new ASPNError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNError from a IQueryable<ASPNError>
        /// </summary>
        public static IQueryable<ASPNError> SelectAsASPNError(this IQueryable<ASPNError> query) => query.Select(other => new ASPNError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNUser(this ASPNUser item, ASPNUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPNAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPNUser.TypeValue)other.Type;
            item.Role = (ASPNUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNUser with fileds filled from ASPNUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNUser ToASPNUser(this ASPNUser other, bool deepClone = true) => new ASPNUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPNAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPNUser.TypeValue)other.Type,
            Role = (ASPNUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNUser from a IQueryable<ASPNUser>
        /// </summary>
        public static IQueryable<ASPNUser> SelectAsASPNUser(this IQueryable<ASPNUser> query) => query.Select(other => new ASPNUser() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPNUser.TypeValue)other.Type,
            Role = (ASPNUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNGuestUser(this ASPNGuestUser item, ASPNGuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (ASPNGuestUser.TypeValue)other.Type;
            item.ConstInt = other.ConstInt;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNGuestUser with fileds filled from ASPNGuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNGuestUser ToASPNGuestUser(this ASPNGuestUser other, bool deepClone = true) => new ASPNGuestUser() { 
            Email = other.Email,
            Type = (ASPNGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNGuestUser from a IQueryable<ASPNGuestUser>
        /// </summary>
        public static IQueryable<ASPNGuestUser> SelectAsASPNGuestUser(this IQueryable<ASPNGuestUser> query) => query.Select(other => new ASPNGuestUser() { 
            Email = other.Email,
            Type = (ASPNGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNUserWithId(this ASPNUserWithId item, ASPNUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPNAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPNUserWithId.TypeValue)other.Type;
            item.Role = (ASPNUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNUserWithId with fileds filled from ASPNUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNUserWithId ToASPNUserWithId(this ASPNUserWithId other, bool deepClone = true) => new ASPNUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPNAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPNUserWithId.TypeValue)other.Type,
            Role = (ASPNUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNUserWithId from a IQueryable<ASPNUserWithId>
        /// </summary>
        public static IQueryable<ASPNUserWithId> SelectAsASPNUserWithId(this IQueryable<ASPNUserWithId> query) => query.Select(other => new ASPNUserWithId() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPNUserWithId.TypeValue)other.Type,
            Role = (ASPNUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = other.Diffs,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNUserWithId(this ASPNUser item, ASPNUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPNAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPNUser.TypeValue)other.Type;
            item.Role = (ASPNUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNUserWithId with fileds filled from ASPNUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNUserWithId ToASPNUserWithId(this ASPNUser other, bool deepClone = true) => new ASPNUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPNAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPNUserWithId.TypeValue)other.Type,
            Role = (ASPNUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNUserWithId from a IQueryable<ASPNUser>
        /// </summary>
        public static IQueryable<ASPNUserWithId> SelectAsASPNUserWithId(this IQueryable<ASPNUser> query) => query.Select(other => new ASPNUserWithId() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPNUserWithId.TypeValue)other.Type,
            Role = (ASPNUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNUser(this ASPNUserWithId item, ASPNUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPNAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPNUserWithId.TypeValue)other.Type;
            item.Role = (ASPNUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNUser with fileds filled from ASPNUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNUser ToASPNUser(this ASPNUserWithId other, bool deepClone = true) => new ASPNUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPNAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPNUser.TypeValue)other.Type,
            Role = (ASPNUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNUser from a IQueryable<ASPNUserWithId>
        /// </summary>
        public static IQueryable<ASPNUser> SelectAsASPNUser(this IQueryable<ASPNUserWithId> query) => query.Select(other => new ASPNUser() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPNUser.TypeValue)other.Type,
            Role = (ASPNUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNPricing(this ASPNPricing item, ASPNPricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNPricing with fileds filled from ASPNPricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNPricing ToASPNPricing(this ASPNPricing other, bool deepClone = true) => new ASPNPricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNPricing from a IQueryable<ASPNPricing>
        /// </summary>
        public static IQueryable<ASPNPricing> SelectAsASPNPricing(this IQueryable<ASPNPricing> query) => query.Select(other => new ASPNPricing() { 
            Price = other.Price,
            Taxes = other.Taxes,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNLongRunningfunctionStatus(this ASPNLongRunningfunctionStatus item, ASPNLongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = (ASPNLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToASPNAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNLongRunningfunctionStatus with fileds filled from ASPNLongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNLongRunningfunctionStatus ToASPNLongRunningfunctionStatus(this ASPNLongRunningfunctionStatus other, bool deepClone = true) => new ASPNLongRunningfunctionStatus() { 
            Status = (ASPNLongRunningfunctionStatus.StatusValue)other.Status,
            Result = deepClone ? other.Result?.ToASPNAnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNLongRunningfunctionStatus from a IQueryable<ASPNLongRunningfunctionStatus>
        /// </summary>
        public static IQueryable<ASPNLongRunningfunctionStatus> SelectAsASPNLongRunningfunctionStatus(this IQueryable<ASPNLongRunningfunctionStatus> query) => query.Select(other => new ASPNLongRunningfunctionStatus() { 
            Status = (ASPNLongRunningfunctionStatus.StatusValue)other.Status,
            Result = other.Result,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNTagInfos(this ASPNTagInfos item, ASPNTagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNTagInfos with fileds filled from ASPNTagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNTagInfos ToASPNTagInfos(this ASPNTagInfos other, bool deepClone = true) => new ASPNTagInfos() { 
            User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNTagInfos from a IQueryable<ASPNTagInfos>
        /// </summary>
        public static IQueryable<ASPNTagInfos> SelectAsASPNTagInfos(this IQueryable<ASPNTagInfos> query) => query.Select(other => new ASPNTagInfos() { 
            User = other.User,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNEnumObject(this ASPNEnumObject item, ASPNEnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.WithDefault = other.WithDefault;
            item.Array = deepClone ? other.Array?.ToList() : other.Array;
            item.Nullable = other.Nullable;
            item.NullableReferenced = other.NullableReferenced;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNEnumObject with fileds filled from ASPNEnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNEnumObject ToASPNEnumObject(this ASPNEnumObject other, bool deepClone = true) => new ASPNEnumObject() { 
            Single = other.Single,
            WithDefault = other.WithDefault,
            Array = deepClone ? other.Array?.ToList() : other.Array,
            Nullable = other.Nullable,
            NullableReferenced = other.NullableReferenced,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNEnumObject from a IQueryable<ASPNEnumObject>
        /// </summary>
        public static IQueryable<ASPNEnumObject> SelectAsASPNEnumObject(this IQueryable<ASPNEnumObject> query) => query.Select(other => new ASPNEnumObject() { 
            Single = other.Single,
            WithDefault = other.WithDefault,
            Array = other.Array,
            Nullable = other.Nullable,
            NullableReferenced = other.NullableReferenced,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNExtendedAddress(this ASPNExtendedAddress item, ASPNExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }
        
        /// <summary>
        /// Returns a new object of ASPNExtendedAddress with fileds filled from ASPNExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNExtendedAddress ToASPNExtendedAddress(this ASPNExtendedAddress other, bool deepClone = true) => new ASPNExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags,
            AddressType2 = other.AddressType2
        };
        
        /// <summary>
        /// Selects the type ASPNExtendedAddress from a IQueryable<ASPNExtendedAddress>
        /// </summary>
        public static IQueryable<ASPNExtendedAddress> SelectAsASPNExtendedAddress(this IQueryable<ASPNExtendedAddress> query) => query.Select(other => new ASPNExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AddressType2 = other.AddressType2
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNExtendedAddress(this ASPNAddress item, ASPNExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPNAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of ASPNExtendedAddress with fileds filled from ASPNAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNExtendedAddress ToASPNExtendedAddress(this ASPNAddress other, bool deepClone = true) => new ASPNExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type ASPNExtendedAddress from a IQueryable<ASPNAddress>
        /// </summary>
        public static IQueryable<ASPNExtendedAddress> SelectAsASPNExtendedAddress(this IQueryable<ASPNAddress> query) => query.Select(other => new ASPNExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNAddress(this ASPNExtendedAddress item, ASPNAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPNExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of ASPNAddress with fileds filled from ASPNExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNAddress ToASPNAddress(this ASPNExtendedAddress other, bool deepClone = true) => new ASPNAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type ASPNAddress from a IQueryable<ASPNExtendedAddress>
        /// </summary>
        public static IQueryable<ASPNAddress> SelectAsASPNAddress(this IQueryable<ASPNExtendedAddress> query) => query.Select(other => new ASPNAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });
    }
}
