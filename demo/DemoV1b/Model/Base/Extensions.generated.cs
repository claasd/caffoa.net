#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoV1b.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Flags(this L2Flags item, L2Flags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of L2Flags with fileds filled from L2Flags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L2Flags ToL2Flags(this L2Flags other, bool deepClone = true) => new L2Flags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type L2Flags from a IQueryable<L2Flags>
        /// </summary>
        public static IQueryable<L2Flags> SelectAsL2Flags(this IQueryable<L2Flags> query) => query.Select(other => new L2Flags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2FlagRef(this L2FlagRef item, L2FlagRef other, bool deepClone = true) {
            item.Flag = deepClone ? other.Flag?.ToL2Flags() : other.Flag;
            item.Flag2 = deepClone ? other.Flag2?.ToL2Flags() : other.Flag2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L2FlagRef with fileds filled from L2FlagRef. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L2FlagRef ToL2FlagRef(this L2FlagRef other, bool deepClone = true) => new L2FlagRef() { 
            Flag = deepClone ? other.Flag?.ToL2Flags() : other.Flag,
            Flag2 = deepClone ? other.Flag2?.ToL2Flags() : other.Flag2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L2FlagRef from a IQueryable<L2FlagRef>
        /// </summary>
        public static IQueryable<L2FlagRef> SelectAsL2FlagRef(this IQueryable<L2FlagRef> query) => query.Select(other => new L2FlagRef() { 
            Flag = other.Flag,
            Flag2 = other.Flag2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Address(this L2Address item, L2Address other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.NumericPostalCode = other.NumericPostalCode;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL2Flags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of L2Address with fileds filled from L2Address. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static L2Address ToL2Address(this L2Address other, bool deepClone = true) => new L2Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToL2Flags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type L2Address from a IQueryable<L2Address>
        /// </summary>
        public static IQueryable<L2Address> SelectAsL2Address(this IQueryable<L2Address> query) => query.Select(other => new L2Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
