using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Pricing {
        public const string PricingObjectName = "pricing";

        public static class PriceValues {
            // constant values for "price"
            public const double _32_99 = 32.99;
            public const double _33_99 = 33.99;
            public const double _44_99 = 44.99;
    
            /// immutable array containing all allowed values for "price"
            public static readonly ImmutableArray<double?> AllowedValues = ImmutableArray.Create<double?>(_32_99, _33_99, _44_99, null);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use PriceValues._32_99 instead.")]
        public const double Price32_99Value = PriceValues._32_99;
        [Obsolete("Will be removed in a future version of caffoa. Use PriceValues._33_99 instead.")]
        public const double Price33_99Value = PriceValues._33_99;
        [Obsolete("Will be removed in a future version of caffoa. Use PriceValues._44_99 instead.")]
        public const double Price44_99Value = PriceValues._44_99;

        [Obsolete("Will be removed in a future version of caffoa. Use PriceValues.AllowedValues instead")]
        public static ImmutableArray<double?> AllowedValuesForPrice { get => PriceValues.AllowedValues; }

        [JsonIgnore]
        private double? _price;

        [JsonProperty("price")]
        public virtual double? Price {
            get {
                return _price;
            }
            set {
                if (!PriceValues.AllowedValues.Contains(value))
                {
                    var allowedValues = string.Join(", ", PriceValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("price",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _price = value;
            }
        }

        [JsonProperty("taxes")]
        public virtual Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

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
            Taxes = other.Taxes;
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
