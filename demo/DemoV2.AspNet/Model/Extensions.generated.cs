#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Caffoa;
using System.Text.Json;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPError(this ASPError item, ASPError other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPError with fileds filled from ASPError. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPError ToASPError(this ASPError other, bool deepClone = true) => new ASPError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPError from a IQueryable<ASPError>
        /// </summary>
        public static IQueryable<ASPError> SelectAsASPError(this IQueryable<ASPError> query) => query.Select(other => new ASPError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPUser(this ASPUser item, ASPUser other, bool deepClone = true) {
            item.SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPUser.TypeValue)other.Type;
            item.Role = (ASPUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPUser with fileds filled from ASPUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPUser ToASPUser(this ASPUser other, bool deepClone = true) => new ASPUser() { 
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums,
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPUser.TypeValue)other.Type,
            Role = (ASPUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPUser from a IQueryable<ASPUser>
        /// </summary>
        public static IQueryable<ASPUser> SelectAsASPUser(this IQueryable<ASPUser> query) => query.Select(other => new ASPUser() { 
            SomeEnums = other.SomeEnums,
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPUser.TypeValue)other.Type,
            Role = (ASPUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPGuestUser(this ASPGuestUser item, ASPGuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (ASPGuestUser.TypeValue)other.Type;
            item.ConstInt = other.ConstInt;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPGuestUser with fileds filled from ASPGuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPGuestUser ToASPGuestUser(this ASPGuestUser other, bool deepClone = true) => new ASPGuestUser() { 
            Email = other.Email,
            Type = (ASPGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPGuestUser from a IQueryable<ASPGuestUser>
        /// </summary>
        public static IQueryable<ASPGuestUser> SelectAsASPGuestUser(this IQueryable<ASPGuestUser> query) => query.Select(other => new ASPGuestUser() { 
            Email = other.Email,
            Type = (ASPGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPUserWithId(this ASPUserWithId item, ASPUserWithId other, bool deepClone = true) {
            item.SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPUserWithId.TypeValue)other.Type;
            item.Role = (ASPUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.Clone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPUserWithId with fileds filled from ASPUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPUserWithId ToASPUserWithId(this ASPUserWithId other, bool deepClone = true) => new ASPUserWithId() { 
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums,
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPUserWithId.TypeValue)other.Type,
            Role = (ASPUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.Clone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPUserWithId from a IQueryable<ASPUserWithId>
        /// </summary>
        public static IQueryable<ASPUserWithId> SelectAsASPUserWithId(this IQueryable<ASPUserWithId> query) => query.Select(other => new ASPUserWithId() { 
            SomeEnums = other.SomeEnums,
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPUserWithId.TypeValue)other.Type,
            Role = (ASPUserWithId.RoleValue)other.Role,
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
        public static void UpdateWithASPUserWithId(this ASPUser item, ASPUserWithId other, bool deepClone = true) {
            item.SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPUser.TypeValue)other.Type;
            item.Role = (ASPUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPUserWithId with fileds filled from ASPUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPUserWithId ToASPUserWithId(this ASPUser other, bool deepClone = true) => new ASPUserWithId() { 
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums,
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPUserWithId.TypeValue)other.Type,
            Role = (ASPUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPUserWithId from a IQueryable<ASPUser>
        /// </summary>
        public static IQueryable<ASPUserWithId> SelectAsASPUserWithId(this IQueryable<ASPUser> query) => query.Select(other => new ASPUserWithId() { 
            SomeEnums = other.SomeEnums,
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPUserWithId.TypeValue)other.Type,
            Role = (ASPUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPUser(this ASPUserWithId item, ASPUser other, bool deepClone = true) {
            item.SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToASPAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (ASPUserWithId.TypeValue)other.Type;
            item.Role = (ASPUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPUser with fileds filled from ASPUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPUser ToASPUser(this ASPUserWithId other, bool deepClone = true) => new ASPUser() { 
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums,
            Name = other.Name,
            Address = deepClone ? other.Address?.ToASPAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (ASPUser.TypeValue)other.Type,
            Role = (ASPUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPUser from a IQueryable<ASPUserWithId>
        /// </summary>
        public static IQueryable<ASPUser> SelectAsASPUser(this IQueryable<ASPUserWithId> query) => query.Select(other => new ASPUser() { 
            SomeEnums = other.SomeEnums,
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (ASPUser.TypeValue)other.Type,
            Role = (ASPUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPPricing(this ASPPricing item, ASPPricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPPricing with fileds filled from ASPPricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPPricing ToASPPricing(this ASPPricing other, bool deepClone = true) => new ASPPricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPPricing from a IQueryable<ASPPricing>
        /// </summary>
        public static IQueryable<ASPPricing> SelectAsASPPricing(this IQueryable<ASPPricing> query) => query.Select(other => new ASPPricing() { 
            Price = other.Price,
            Taxes = other.Taxes,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPLongRunningfunctionStatus(this ASPLongRunningfunctionStatus item, ASPLongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = other.Status == null ? null : (ASPLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToASPAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPLongRunningfunctionStatus with fileds filled from ASPLongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPLongRunningfunctionStatus ToASPLongRunningfunctionStatus(this ASPLongRunningfunctionStatus other, bool deepClone = true) => new ASPLongRunningfunctionStatus() { 
            Status = other.Status == null ? null : (ASPLongRunningfunctionStatus.StatusValue)other.Status,
            Result = deepClone ? other.Result?.ToASPAnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPLongRunningfunctionStatus from a IQueryable<ASPLongRunningfunctionStatus>
        /// </summary>
        public static IQueryable<ASPLongRunningfunctionStatus> SelectAsASPLongRunningfunctionStatus(this IQueryable<ASPLongRunningfunctionStatus> query) => query.Select(other => new ASPLongRunningfunctionStatus() { 
            Status = other.Status == null ? null : (ASPLongRunningfunctionStatus.StatusValue)other.Status,
            Result = other.Result,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPTagInfos(this ASPTagInfos item, ASPTagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPTagInfos with fileds filled from ASPTagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPTagInfos ToASPTagInfos(this ASPTagInfos other, bool deepClone = true) => new ASPTagInfos() { 
            User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPTagInfos from a IQueryable<ASPTagInfos>
        /// </summary>
        public static IQueryable<ASPTagInfos> SelectAsASPTagInfos(this IQueryable<ASPTagInfos> query) => query.Select(other => new ASPTagInfos() { 
            User = other.User,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPEnumObject(this ASPEnumObject item, ASPEnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.WithDefault = other.WithDefault;
            item.Array = deepClone ? other.Array?.ToList() : other.Array;
            item.Nullable = other.Nullable;
            item.NullableReferenced = other.NullableReferenced;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPEnumObject with fileds filled from ASPEnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPEnumObject ToASPEnumObject(this ASPEnumObject other, bool deepClone = true) => new ASPEnumObject() { 
            Single = other.Single,
            WithDefault = other.WithDefault,
            Array = deepClone ? other.Array?.ToList() : other.Array,
            Nullable = other.Nullable,
            NullableReferenced = other.NullableReferenced,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPEnumObject from a IQueryable<ASPEnumObject>
        /// </summary>
        public static IQueryable<ASPEnumObject> SelectAsASPEnumObject(this IQueryable<ASPEnumObject> query) => query.Select(other => new ASPEnumObject() { 
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
        public static void UpdateWithASPExtendedAddress(this ASPExtendedAddress item, ASPExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.NumericPostalCode = other.NumericPostalCode;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }
        
        /// <summary>
        /// Returns a new object of ASPExtendedAddress with fileds filled from ASPExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPExtendedAddress ToASPExtendedAddress(this ASPExtendedAddress other, bool deepClone = true) => new ASPExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags,
            AddressType2 = other.AddressType2
        };
        
        /// <summary>
        /// Selects the type ASPExtendedAddress from a IQueryable<ASPExtendedAddress>
        /// </summary>
        public static IQueryable<ASPExtendedAddress> SelectAsASPExtendedAddress(this IQueryable<ASPExtendedAddress> query) => query.Select(other => new ASPExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AddressType2 = other.AddressType2
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPExtendedAddress(this ASPAddress item, ASPExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.NumericPostalCode = other.NumericPostalCode;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of ASPExtendedAddress with fileds filled from ASPAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPExtendedAddress ToASPExtendedAddress(this ASPAddress other, bool deepClone = true) => new ASPExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type ASPExtendedAddress from a IQueryable<ASPAddress>
        /// </summary>
        public static IQueryable<ASPExtendedAddress> SelectAsASPExtendedAddress(this IQueryable<ASPAddress> query) => query.Select(other => new ASPExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPAddress(this ASPExtendedAddress item, ASPAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.NumericPostalCode = other.NumericPostalCode;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of ASPAddress with fileds filled from ASPExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPAddress ToASPAddress(this ASPExtendedAddress other, bool deepClone = true) => new ASPAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type ASPAddress from a IQueryable<ASPExtendedAddress>
        /// </summary>
        public static IQueryable<ASPAddress> SelectAsASPAddress(this IQueryable<ASPExtendedAddress> query) => query.Select(other => new ASPAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPGroupedOneOf(this ASPGroupedOneOf item, ASPGroupedOneOf other, bool deepClone = true) {
            item.Element = deepClone ? other.Element?.ToASPAnyUser() : other.Element;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPGroupedOneOf with fileds filled from ASPGroupedOneOf. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPGroupedOneOf ToASPGroupedOneOf(this ASPGroupedOneOf other, bool deepClone = true) => new ASPGroupedOneOf() { 
            Element = deepClone ? other.Element?.ToASPAnyUser() : other.Element,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPGroupedOneOf from a IQueryable<ASPGroupedOneOf>
        /// </summary>
        public static IQueryable<ASPGroupedOneOf> SelectAsASPGroupedOneOf(this IQueryable<ASPGroupedOneOf> query) => query.Select(other => new ASPGroupedOneOf() { 
            Element = other.Element,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
