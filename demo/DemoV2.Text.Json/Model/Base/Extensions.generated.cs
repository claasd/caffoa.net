#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DemoV2.Text.Json.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJFlags(this STJFlags item, STJFlags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of STJFlags with fileds filled from STJFlags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJFlags ToSTJFlags(this STJFlags other, bool deepClone = true) => new STJFlags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type STJFlags from a IQueryable<STJFlags>
        /// </summary>
        public static IQueryable<STJFlags> SelectAsSTJFlags(this IQueryable<STJFlags> query) => query.Select(other => new STJFlags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJFlagRef(this STJFlagRef item, STJFlagRef other, bool deepClone = true) {
            item.Flag = deepClone ? other.Flag?.ToSTJFlags() : other.Flag;
            item.Flag2 = deepClone ? other.Flag2?.ToSTJFlags() : other.Flag2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJFlagRef with fileds filled from STJFlagRef. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJFlagRef ToSTJFlagRef(this STJFlagRef other, bool deepClone = true) => new STJFlagRef() { 
            Flag = deepClone ? other.Flag?.ToSTJFlags() : other.Flag,
            Flag2 = deepClone ? other.Flag2?.ToSTJFlags() : other.Flag2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type STJFlagRef from a IQueryable<STJFlagRef>
        /// </summary>
        public static IQueryable<STJFlagRef> SelectAsSTJFlagRef(this IQueryable<STJFlagRef> query) => query.Select(other => new STJFlagRef() { 
            Flag = other.Flag,
            Flag2 = other.Flag2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSTJAddress(this STJAddress item, STJAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (STJAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of STJAddress with fileds filled from STJAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static STJAddress ToSTJAddress(this STJAddress other, bool deepClone = true) => new STJAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (STJAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToSTJFlags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type STJAddress from a IQueryable<STJAddress>
        /// </summary>
        public static IQueryable<STJAddress> SelectAsSTJAddress(this IQueryable<STJAddress> query) => query.Select(other => new STJAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (STJAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
