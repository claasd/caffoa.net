#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Caffoa;
using Newtonsoft.Json.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Error(this L1Error item, L1Error other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1Error with fileds filled from L1Error. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1Error ToL1Error(this L1Error other, bool deepClone = true) => new L1Error() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1Error from a IQueryable<L1Error>
        /// </summary>
        public static IQueryable<L1Error> SelectAsL1Error(this IQueryable<L1Error> query) => query.Select(other => new L1Error() { 
            Status = other.Status,
            Message = other.Message,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1User(this L1User item, L1User other, bool deepClone = true) {
            item.SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            item.Name = other.Name;
            item.Address = deepClone ? other.Address?.ToL1Address() : other.Address;
            item.Birthdate = other.Birthdate;
            item.Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            item.Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            item.Type = other.Type;
            item.Role = other.Role;
            item.AgeGroup = other.AgeGroup;
            item.PreferredContactTime = other.PreferredContactTime;
            item.LastSessionLength = other.LastSessionLength;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1User with fileds filled from L1User. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1User ToL1User(this L1User other, bool deepClone = true) => new L1User() { 
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums,
            Name = other.Name,
            Address = deepClone ? other.Address?.ToL1Address() : other.Address,
            Birthdate = other.Birthdate,
            Emails = deepClone ? other.Emails?.ToList() : other.Emails,
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions,
            Type = other.Type,
            Role = other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1User from a IQueryable<L1User>
        /// </summary>
        public static IQueryable<L1User> SelectAsL1User(this IQueryable<L1User> query) => query.Select(other => new L1User() { 
            SomeEnums = other.SomeEnums,
            Name = other.Name,
            Address = other.Address,
            Birthdate = other.Birthdate,
            Emails = other.Emails,
            Descriptions = other.Descriptions,
            Type = other.Type,
            Role = other.Role,
            AgeGroup = other.AgeGroup,
            PreferredContactTime = other.PreferredContactTime,
            LastSessionLength = other.LastSessionLength,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1GuestUser(this L1GuestUser item, L1GuestUser other, bool deepClone = true) {
            item.Email = other.Email;
            item.Type = other.Type;
            item.ConstInt = other.ConstInt;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1GuestUser with fileds filled from L1GuestUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1GuestUser ToL1GuestUser(this L1GuestUser other, bool deepClone = true) => new L1GuestUser() { 
            Email = other.Email,
            Type = other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1GuestUser from a IQueryable<L1GuestUser>
        /// </summary>
        public static IQueryable<L1GuestUser> SelectAsL1GuestUser(this IQueryable<L1GuestUser> query) => query.Select(other => new L1GuestUser() { 
            Email = other.Email,
            Type = other.Type,
            ConstInt = other.ConstInt,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1UserWithId(this L1UserWithId item, L1UserWithId other, bool deepClone = true) {
            item.Id = other.Id;
            item.RegistrationDate = other.RegistrationDate;
            item.Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1UserWithId with fileds filled from L1UserWithId. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1UserWithId ToL1UserWithId(this L1UserWithId other, bool deepClone = true) => new L1UserWithId() { 
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = deepClone ? other.Diffs?.DeepClone() : other.Diffs,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1UserWithId from a IQueryable<L1UserWithId>
        /// </summary>
        public static IQueryable<L1UserWithId> SelectAsL1UserWithId(this IQueryable<L1UserWithId> query) => query.Select(other => new L1UserWithId() { 
            Id = other.Id,
            RegistrationDate = other.RegistrationDate,
            Diffs = other.Diffs,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Pricing(this L1Pricing item, L1Pricing other, bool deepClone = true) {
            item.Price = other.Price;
            item.Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1Pricing with fileds filled from L1Pricing. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1Pricing ToL1Pricing(this L1Pricing other, bool deepClone = true) => new L1Pricing() { 
            Price = other.Price,
            Taxes = deepClone ? other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Taxes,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1Pricing from a IQueryable<L1Pricing>
        /// </summary>
        public static IQueryable<L1Pricing> SelectAsL1Pricing(this IQueryable<L1Pricing> query) => query.Select(other => new L1Pricing() { 
            Price = other.Price,
            Taxes = other.Taxes,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1LongRunningfunctionStatus(this L1LongRunningfunctionStatus item, L1LongRunningfunctionStatus other, bool deepClone = true) {
            item.Status = other.Status;
            item.Result = deepClone ? other.Result?.ToL1AnyUser() : other.Result;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1LongRunningfunctionStatus with fileds filled from L1LongRunningfunctionStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1LongRunningfunctionStatus ToL1LongRunningfunctionStatus(this L1LongRunningfunctionStatus other, bool deepClone = true) => new L1LongRunningfunctionStatus() { 
            Status = other.Status,
            Result = deepClone ? other.Result?.ToL1AnyUser() : other.Result,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1LongRunningfunctionStatus from a IQueryable<L1LongRunningfunctionStatus>
        /// </summary>
        public static IQueryable<L1LongRunningfunctionStatus> SelectAsL1LongRunningfunctionStatus(this IQueryable<L1LongRunningfunctionStatus> query) => query.Select(other => new L1LongRunningfunctionStatus() { 
            Status = other.Status,
            Result = other.Result,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1TagInfos(this L1TagInfos item, L1TagInfos other, bool deepClone = true) {
            item.User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1TagInfos with fileds filled from L1TagInfos. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1TagInfos ToL1TagInfos(this L1TagInfos other, bool deepClone = true) => new L1TagInfos() { 
            User = deepClone ? other.User?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.User,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1TagInfos from a IQueryable<L1TagInfos>
        /// </summary>
        public static IQueryable<L1TagInfos> SelectAsL1TagInfos(this IQueryable<L1TagInfos> query) => query.Select(other => new L1TagInfos() { 
            User = other.User,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1EnumObject(this L1EnumObject item, L1EnumObject other, bool deepClone = true) {
            item.Single = other.Single;
            item.WithDefault = other.WithDefault;
            item.Array = deepClone ? other.Array?.ToList() : other.Array;
            item.Nullable = other.Nullable;
            item.NullableReferenced = other.NullableReferenced;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1EnumObject with fileds filled from L1EnumObject. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1EnumObject ToL1EnumObject(this L1EnumObject other, bool deepClone = true) => new L1EnumObject() { 
            Single = other.Single,
            WithDefault = other.WithDefault,
            Array = deepClone ? other.Array?.ToList() : other.Array,
            Nullable = other.Nullable,
            NullableReferenced = other.NullableReferenced,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1EnumObject from a IQueryable<L1EnumObject>
        /// </summary>
        public static IQueryable<L1EnumObject> SelectAsL1EnumObject(this IQueryable<L1EnumObject> query) => query.Select(other => new L1EnumObject() { 
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
        public static void UpdateWithL1ExtendedAddress(this L1ExtendedAddress item, L1ExtendedAddress other, bool deepClone = true) {
            item.AddressType2 = other.AddressType2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1ExtendedAddress with fileds filled from L1ExtendedAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1ExtendedAddress ToL1ExtendedAddress(this L1ExtendedAddress other, bool deepClone = true) => new L1ExtendedAddress() { 
            AddressType2 = other.AddressType2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1ExtendedAddress from a IQueryable<L1ExtendedAddress>
        /// </summary>
        public static IQueryable<L1ExtendedAddress> SelectAsL1ExtendedAddress(this IQueryable<L1ExtendedAddress> query) => query.Select(other => new L1ExtendedAddress() { 
            AddressType2 = other.AddressType2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1GroupedOneOf(this L1GroupedOneOf item, L1GroupedOneOf other, bool deepClone = true) {
            item.Element = deepClone ? other.Element?.ToL1AnyUser() : other.Element;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1GroupedOneOf with fileds filled from L1GroupedOneOf. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1GroupedOneOf ToL1GroupedOneOf(this L1GroupedOneOf other, bool deepClone = true) => new L1GroupedOneOf() { 
            Element = deepClone ? other.Element?.ToL1AnyUser() : other.Element,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1GroupedOneOf from a IQueryable<L1GroupedOneOf>
        /// </summary>
        public static IQueryable<L1GroupedOneOf> SelectAsL1GroupedOneOf(this IQueryable<L1GroupedOneOf> query) => query.Select(other => new L1GroupedOneOf() { 
            Element = other.Element,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
