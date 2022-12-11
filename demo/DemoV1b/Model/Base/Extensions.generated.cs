using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DemoV1b.Model.Base {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Flags(this L2Flags item, L2Flags other) {
            item.Id = other.Id;
            item.Desc = other.Desc;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithL2Address(this L2Address item, L2Address other) {
            item.Street = other.Street;
            item.StreetExtra = other.StreetExtra;
            item.PostalCode = other.PostalCode;
            item.City = other.City;
            item.Country = other.Country;
            item.Flags = other.Flags.ToDictionary(entry => entry.Key, entry => entry.Value.ToL2Flags());
        }
    }
}
