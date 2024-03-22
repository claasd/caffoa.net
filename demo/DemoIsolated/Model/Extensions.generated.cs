#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoError(this IsoError item, IsoError other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoError with fileds filled from IsoError. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoError ToIsoError(this IsoError other, bool deepClone = true) => new IsoError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoError from a IQueryable<IsoError>
        /// </summary>
        public static IQueryable<IsoError> SelectAsIsoError(this IQueryable<IsoError> query) => query.Select(other => new IsoError() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoUser(this IsoUser item, IsoUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToIsoAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (IsoUser.TypeValue)other.Type;
            item.Role = (IsoUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoUser with fileds filled from IsoUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoUser ToIsoUser(this IsoUser other, bool deepClone = true) => new IsoUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToIsoAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (IsoUser.TypeValue)other.Type,
            Role = (IsoUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoUser from a IQueryable<IsoUser>
        /// </summary>
        public static IQueryable<IsoUser> SelectAsIsoUser(this IQueryable<IsoUser> query) => query.Select(other => new IsoUser() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (IsoUser.TypeValue)other.Type,
            Role = (IsoUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoGuestUser(this IsoGuestUser item, IsoGuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = (IsoGuestUser.TypeValue)other.Type;
            item.ConstInt = other.ConstInt;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoGuestUser with fileds filled from IsoGuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoGuestUser ToIsoGuestUser(this IsoGuestUser other, bool deepClone = true) => new IsoGuestUser() { 
            Email = other.Email,
            Type = (IsoGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoGuestUser from a IQueryable<IsoGuestUser>
        /// </summary>
        public static IQueryable<IsoGuestUser> SelectAsIsoGuestUser(this IQueryable<IsoGuestUser> query) => query.Select(other => new IsoGuestUser() { 
            Email = other.Email,
            Type = (IsoGuestUser.TypeValue)other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoUserWithId(this IsoUserWithId item, IsoUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToIsoAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (IsoUserWithId.TypeValue)other.Type;
            item.Role = (IsoUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoUserWithId with fileds filled from IsoUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoUserWithId ToIsoUserWithId(this IsoUserWithId other, bool deepClone = true) => new IsoUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToIsoAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (IsoUserWithId.TypeValue)other.Type,
            Role = (IsoUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoUserWithId from a IQueryable<IsoUserWithId>
        /// </summary>
        public static IQueryable<IsoUserWithId> SelectAsIsoUserWithId(this IQueryable<IsoUserWithId> query) => query.Select(other => new IsoUserWithId() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (IsoUserWithId.TypeValue)other.Type,
            Role = (IsoUserWithId.RoleValue)other.Role,
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
        public static void UpdateWithIsoUserWithId(this IsoUser item, IsoUserWithId other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToIsoAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (IsoUser.TypeValue)other.Type;
            item.Role = (IsoUser.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoUserWithId with fileds filled from IsoUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoUserWithId ToIsoUserWithId(this IsoUser other, bool deepClone = true) => new IsoUserWithId() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToIsoAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (IsoUserWithId.TypeValue)other.Type,
            Role = (IsoUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoUserWithId from a IQueryable<IsoUser>
        /// </summary>
        public static IQueryable<IsoUserWithId> SelectAsIsoUserWithId(this IQueryable<IsoUser> query) => query.Select(other => new IsoUserWithId() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (IsoUserWithId.TypeValue)other.Type,
            Role = (IsoUserWithId.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoUser(this IsoUserWithId item, IsoUser other, bool deepClone = true) {
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToIsoAddress() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = (IsoUserWithId.TypeValue)other.Type;
            item.Role = (IsoUserWithId.RoleValue)other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoUser with fileds filled from IsoUserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoUser ToIsoUser(this IsoUserWithId other, bool deepClone = true) => new IsoUser() { 
            Name = other.Name,
            Address = deepClone ? other.Address?.ToIsoAddress() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = (IsoUser.TypeValue)other.Type,
            Role = (IsoUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoUser from a IQueryable<IsoUserWithId>
        /// </summary>
        public static IQueryable<IsoUser> SelectAsIsoUser(this IQueryable<IsoUserWithId> query) => query.Select(other => new IsoUser() { 
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = (IsoUser.TypeValue)other.Type,
            Role = (IsoUser.RoleValue)other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoPricing(this IsoPricing item, IsoPricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoPricing with fileds filled from IsoPricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoPricing ToIsoPricing(this IsoPricing other, bool deepClone = true) => new IsoPricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoPricing from a IQueryable<IsoPricing>
        /// </summary>
        public static IQueryable<IsoPricing> SelectAsIsoPricing(this IQueryable<IsoPricing> query) => query.Select(other => new IsoPricing() { 
            Price = other.Price,
            Taxes = other.Taxes,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoLongRunningfunctionStatus(this IsoLongRunningfunctionStatus item, IsoLongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = other.Status == null ? null : (IsoLongRunningfunctionStatus.StatusValue)other.Status;
            item.Result = deepClone ? other.Result?.ToIsoAnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoLongRunningfunctionStatus with fileds filled from IsoLongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoLongRunningfunctionStatus ToIsoLongRunningfunctionStatus(this IsoLongRunningfunctionStatus other, bool deepClone = true) => new IsoLongRunningfunctionStatus() { 
            Status = other.Status == null ? null : (IsoLongRunningfunctionStatus.StatusValue)other.Status,
            Result = deepClone ? other.Result?.ToIsoAnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoLongRunningfunctionStatus from a IQueryable<IsoLongRunningfunctionStatus>
        /// </summary>
        public static IQueryable<IsoLongRunningfunctionStatus> SelectAsIsoLongRunningfunctionStatus(this IQueryable<IsoLongRunningfunctionStatus> query) => query.Select(other => new IsoLongRunningfunctionStatus() { 
            Status = other.Status == null ? null : (IsoLongRunningfunctionStatus.StatusValue)other.Status,
            Result = other.Result,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoTagInfos(this IsoTagInfos item, IsoTagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoTagInfos with fileds filled from IsoTagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoTagInfos ToIsoTagInfos(this IsoTagInfos other, bool deepClone = true) => new IsoTagInfos() { 
            User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoTagInfos from a IQueryable<IsoTagInfos>
        /// </summary>
        public static IQueryable<IsoTagInfos> SelectAsIsoTagInfos(this IQueryable<IsoTagInfos> query) => query.Select(other => new IsoTagInfos() { 
            User = other.User,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoEnumObject(this IsoEnumObject item, IsoEnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.WithDefault = other.WithDefault;
            item.Array = deepClone ? other.Array?.ToList() : other.Array;
            item.Nullable = other.Nullable;
            item.NullableReferenced = other.NullableReferenced;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoEnumObject with fileds filled from IsoEnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoEnumObject ToIsoEnumObject(this IsoEnumObject other, bool deepClone = true) => new IsoEnumObject() { 
            Single = other.Single,
            WithDefault = other.WithDefault,
            Array = deepClone ? other.Array?.ToList() : other.Array,
            Nullable = other.Nullable,
            NullableReferenced = other.NullableReferenced,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoEnumObject from a IQueryable<IsoEnumObject>
        /// </summary>
        public static IQueryable<IsoEnumObject> SelectAsIsoEnumObject(this IQueryable<IsoEnumObject> query) => query.Select(other => new IsoEnumObject() { 
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
        public static void UpdateWithIsoExtendedAddress(this IsoExtendedAddress item, IsoExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
            item.AddressType2 = other.AddressType2;
        }
        
        /// <summary>
        /// Returns a new object of IsoExtendedAddress with fileds filled from IsoExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoExtendedAddress ToIsoExtendedAddress(this IsoExtendedAddress other, bool deepClone = true) => new IsoExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags,
            AddressType2 = other.AddressType2
        };
        
        /// <summary>
        /// Selects the type IsoExtendedAddress from a IQueryable<IsoExtendedAddress>
        /// </summary>
        public static IQueryable<IsoExtendedAddress> SelectAsIsoExtendedAddress(this IQueryable<IsoExtendedAddress> query) => query.Select(other => new IsoExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AddressType2 = other.AddressType2
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoExtendedAddress(this IsoAddress item, IsoExtendedAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (IsoAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of IsoExtendedAddress with fileds filled from IsoAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoExtendedAddress ToIsoExtendedAddress(this IsoAddress other, bool deepClone = true) => new IsoExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type IsoExtendedAddress from a IQueryable<IsoAddress>
        /// </summary>
        public static IQueryable<IsoExtendedAddress> SelectAsIsoExtendedAddress(this IQueryable<IsoAddress> query) => query.Select(other => new IsoExtendedAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoAddress(this IsoExtendedAddress item, IsoAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (IsoExtendedAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
        }
        
        /// <summary>
        /// Returns a new object of IsoAddress with fileds filled from IsoExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoAddress ToIsoAddress(this IsoExtendedAddress other, bool deepClone = true) => new IsoAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags
        };
        
        /// <summary>
        /// Selects the type IsoAddress from a IQueryable<IsoExtendedAddress>
        /// </summary>
        public static IQueryable<IsoAddress> SelectAsIsoAddress(this IQueryable<IsoExtendedAddress> query) => query.Select(other => new IsoAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoGroupedOneOf(this IsoGroupedOneOf item, IsoGroupedOneOf other, bool deepClone = true) {
            item.Element = deepClone ? other.Element?.ToIsoAnyUser() : other.Element;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoGroupedOneOf with fileds filled from IsoGroupedOneOf. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoGroupedOneOf ToIsoGroupedOneOf(this IsoGroupedOneOf other, bool deepClone = true) => new IsoGroupedOneOf() { 
            Element = deepClone ? other.Element?.ToIsoAnyUser() : other.Element,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoGroupedOneOf from a IQueryable<IsoGroupedOneOf>
        /// </summary>
        public static IQueryable<IsoGroupedOneOf> SelectAsIsoGroupedOneOf(this IQueryable<IsoGroupedOneOf> query) => query.Select(other => new IsoGroupedOneOf() { 
            Element = other.Element,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
