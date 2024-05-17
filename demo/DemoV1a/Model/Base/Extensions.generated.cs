#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoV1a.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Flags(this L1Flags item, L1Flags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of L1Flags with fileds filled from L1Flags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1Flags ToL1Flags(this L1Flags other, bool deepClone = true) => new L1Flags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type L1Flags from a IQueryable<L1Flags>
        /// </summary>
        public static IQueryable<L1Flags> SelectAsL1Flags(this IQueryable<L1Flags> query) => query.Select(other => new L1Flags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1FlagRef(this L1FlagRef item, L1FlagRef other, bool deepClone = true) {
            item.Flag = deepClone ? other.Flag?.ToL1Flags() : other.Flag;
            item.Flag2 = deepClone ? other.Flag2?.ToL1Flags() : other.Flag2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1FlagRef with fileds filled from L1FlagRef. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1FlagRef ToL1FlagRef(this L1FlagRef other, bool deepClone = true) => new L1FlagRef() { 
            Flag = deepClone ? other.Flag?.ToL1Flags() : other.Flag,
            Flag2 = deepClone ? other.Flag2?.ToL1Flags() : other.Flag2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1FlagRef from a IQueryable<L1FlagRef>
        /// </summary>
        public static IQueryable<L1FlagRef> SelectAsL1FlagRef(this IQueryable<L1FlagRef> query) => query.Select(other => new L1FlagRef() { 
            Flag = other.Flag,
            Flag2 = other.Flag2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL1Address(this L1Address item, L1Address other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL1Flags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L1Address with fileds filled from L1Address. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L1Address ToL1Address(this L1Address other, bool deepClone = true) => new L1Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL1Flags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L1Address from a IQueryable<L1Address>
        /// </summary>
        public static IQueryable<L1Address> SelectAsL1Address(this IQueryable<L1Address> query) => query.Select(other => new L1Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
