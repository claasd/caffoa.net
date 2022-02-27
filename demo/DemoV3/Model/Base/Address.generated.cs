using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DemoV3.Model.Base {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Address {
        public const string AddressObjectName = "address";

        [JsonProperty("street", Required = Required.Always)]
        public virtual string Street { get; set; }

        [JsonProperty("street.extra")]
        public virtual string StreetExtra { get; set; }

        [JsonProperty("postalCode", Required = Required.Always)]
        public virtual string PostalCode { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public virtual string City { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public virtual string Country { get; set; }

        [JsonProperty("flags")]
        public virtual Dictionary<string, Flags> Flags { get; set; } = new Dictionary<string, Flags>();

        [JsonExtensionData]
        public Dictionary<string, JToken> AdditionalProperties;

        public Address ToAddress() {
            var item = new Address();
            item.UpdateWithAddress(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithAddress(Address other) {
            Street = other.Street;
            StreetExtra = other.StreetExtra;
            PostalCode = other.PostalCode;
            City = other.City;
            Country = other.Country;
            Flags = other.Flags;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, JToken>(other.AdditionalProperties) : null;
        }

        /// <summary>
        /// Merges all fields of Address that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAddress(Address other, JsonMergeSettings mergeSettings = null) {
            MergeWithAddress(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of Address that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithAddress(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithAddress(sourceObject.ToObject<Address>());
        }
    }
}
