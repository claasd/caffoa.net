using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Pricing {
        public const string PricingObjectName = "pricing";

        // constant values for "price"
        public const double Price32_99Value = 32.99;
        public const double Price33_99Value = 33.99;
        public const double Price44_99Value = 44.99;

        /// <summary>
        /// immutable array containing all allowed values for "price"
        /// </summary>
        public static readonly ImmutableArray<double?> AllowedValuesForPrice = ImmutableArray.Create<double?>(Price32_99Value, Price33_99Value, Price44_99Value, null);

        [JsonIgnore]
        private double? _price;

        [JsonProperty("price")]
        public virtual double? Price {
            get {
                return _price;
            }
            set {
                if (!AllowedValuesForPrice.Contains(value))
                {
                    var allowedValues = string.Join(", ", AllowedValuesForPrice.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("price",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _price = value;
            }
        }

        public Pricing ToPricing() {
            var item = new Pricing();
            item.UpdateWithPricing(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithPricing(Pricing other) {
            Price = other.Price;
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
