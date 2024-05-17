#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoIsolated.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoFlags(this IsoFlags item, IsoFlags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of IsoFlags with fileds filled from IsoFlags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoFlags ToIsoFlags(this IsoFlags other, bool deepClone = true) => new IsoFlags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type IsoFlags from a IQueryable<IsoFlags>
        /// </summary>
        public static IQueryable<IsoFlags> SelectAsIsoFlags(this IQueryable<IsoFlags> query) => query.Select(other => new IsoFlags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoFlagRef(this IsoFlagRef item, IsoFlagRef other, bool deepClone = true) {
            item.Flag = deepClone ? other.Flag?.ToIsoFlags() : other.Flag;
            item.Flag2 = deepClone ? other.Flag2?.ToIsoFlags() : other.Flag2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoFlagRef with fileds filled from IsoFlagRef. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoFlagRef ToIsoFlagRef(this IsoFlagRef other, bool deepClone = true) => new IsoFlagRef() { 
            Flag = deepClone ? other.Flag?.ToIsoFlags() : other.Flag,
            Flag2 = deepClone ? other.Flag2?.ToIsoFlags() : other.Flag2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoFlagRef from a IQueryable<IsoFlagRef>
        /// </summary>
        public static IQueryable<IsoFlagRef> SelectAsIsoFlagRef(this IQueryable<IsoFlagRef> query) => query.Select(other => new IsoFlagRef() { 
            Flag = other.Flag,
            Flag2 = other.Flag2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIsoAddress(this IsoAddress item, IsoAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (IsoAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of IsoAddress with fileds filled from IsoAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IsoAddress ToIsoAddress(this IsoAddress other, bool deepClone = true) => new IsoAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToIsoFlags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type IsoAddress from a IQueryable<IsoAddress>
        /// </summary>
        public static IQueryable<IsoAddress> SelectAsIsoAddress(this IQueryable<IsoAddress> query) => query.Select(other => new IsoAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (IsoAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
