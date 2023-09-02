#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoV2.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFlags(this Flags item, Flags other, bool deepClone = false) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }
        
        /// <summary>
        /// Returns a new object of Flags with fileds filled from Flags. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Flags ToFlags(this Flags other, bool deepClone = false) => new Flags() { 
            Id = other.Id,
            Desc = other.Desc
        };
        
        /// <summary>
        /// Selects the type Flags from a IQueryable<Flags>
        /// </summary>
        public static IQueryable<Flags> SelectAsFlags(this IQueryable<Flags> query) => query.Select(other => new Flags() { 
            Id = other.Id,
            Desc = other.Desc
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithAddress(this Address item, Address other, bool deepClone = false) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.AddressType = (Address.AddressTypeValue)other.AddressType;
            item.Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFlags()) : other.Flags;
            item.AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        
        /// <summary>
        /// Returns a new object of Address with fileds filled from Address. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Address ToAddress(this Address other, bool deepClone = false) => new Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (Address.AddressTypeValue)other.AddressType,
            Flags = deepClone ? other.Flags?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFlags()) : other.Flags,
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties
        };
        
        /// <summary>
        /// Selects the type Address from a IQueryable<Address>
        /// </summary>
        public static IQueryable<Address> SelectAsAddress(this IQueryable<Address> query) => query.Select(other => new Address() { 
            Street = other.Street,
            StreetExtra = other.StreetExtra,
            PostalCode = other.PostalCode,
            City = other.City,
            Country = other.Country,
            AddressType = (Address.AddressTypeValue)other.AddressType,
            Flags = other.Flags,
            AdditionalProperties = other.AdditionalProperties
        });
    }
}
