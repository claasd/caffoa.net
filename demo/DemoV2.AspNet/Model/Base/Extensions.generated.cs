#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DemoV2.AspNet.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPFlags(this ASPFlags item, ASPFlags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of ASPFlags with fileds filled from ASPFlags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPFlags ToASPFlags(this ASPFlags other, bool deepClone = true) => new ASPFlags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type ASPFlags from a IQueryable<ASPFlags>
        /// </summary>
        public static IQueryable<ASPFlags> SelectAsASPFlags(this IQueryable<ASPFlags> query) => query.Select(other => new ASPFlags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPAddress(this ASPAddress item, ASPAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPAddress with fileds filled from ASPAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPAddress ToASPAddress(this ASPAddress other, bool deepClone = true) => new ASPAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPFlags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPAddress from a IQueryable<ASPAddress>
        /// </summary>
        public static IQueryable<ASPAddress> SelectAsASPAddress(this IQueryable<ASPAddress> query) => query.Select(other => new ASPAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
