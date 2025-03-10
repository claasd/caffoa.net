#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Caffoa;
using Newtonsoft.Json.Linq;

namespace DemoV2.AspNetNewtonSoft.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNFlags(this ASPNFlags item, ASPNFlags other, bool deepClone = true) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of ASPNFlags with fileds filled from ASPNFlags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNFlags ToASPNFlags(this ASPNFlags other, bool deepClone = true) => new ASPNFlags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type ASPNFlags from a IQueryable<ASPNFlags>
        /// </summary>
        public static IQueryable<ASPNFlags> SelectAsASPNFlags(this IQueryable<ASPNFlags> query) => query.Select(other => new ASPNFlags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNFlagRef(this ASPNFlagRef item, ASPNFlagRef other, bool deepClone = true) {
            item.Flag = deepClone ? other.Flag?.ToASPNFlags() : other.Flag;
            item.Flag2 = deepClone ? other.Flag2?.ToASPNFlags() : other.Flag2;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNFlagRef with fileds filled from ASPNFlagRef. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNFlagRef ToASPNFlagRef(this ASPNFlagRef other, bool deepClone = true) => new ASPNFlagRef() { 
            Flag = deepClone ? other.Flag?.ToASPNFlags() : other.Flag,
            Flag2 = deepClone ? other.Flag2?.ToASPNFlags() : other.Flag2,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNFlagRef from a IQueryable<ASPNFlagRef>
        /// </summary>
        public static IQueryable<ASPNFlagRef> SelectAsASPNFlagRef(this IQueryable<ASPNFlagRef> query) => query.Select(other => new ASPNFlagRef() { 
            Flag = other.Flag,
            Flag2 = other.Flag2,
            AdditionalProperties = other.AdditionalProperties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithASPNAddress(this ASPNAddress item, ASPNAddress other, bool deepClone = true) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.NumericPostalCode = other.NumericPostalCode;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (ASPNAddress.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of ASPNAddress with fileds filled from ASPNAddress. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ASPNAddress ToASPNAddress(this ASPNAddress other, bool deepClone = true) => new ASPNAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNAddress.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToASPNFlags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type ASPNAddress from a IQueryable<ASPNAddress>
        /// </summary>
        public static IQueryable<ASPNAddress> SelectAsASPNAddress(this IQueryable<ASPNAddress> query) => query.Select(other => new ASPNAddress() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            NumericPostalCode = other.NumericPostalCode,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (ASPNAddress.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
