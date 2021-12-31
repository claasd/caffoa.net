using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class Pricing {
        public const string PricingObjectName = "pricing";


        public Pricing ToPricing() {
            var item = new Pricing();
            item.UpdateWithPricing(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithPricing(Pricing other) {
            
        }

        /// <summary>
        /// Merges all fields of Pricing that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithPricing(Pricing other, JsonMergeSettings mergeSettings = null) {
            MergeWithPricing(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of Pricing that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithPricing(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithPricing(sourceObject.ToObject<Pricing>());
        }
    }
}
