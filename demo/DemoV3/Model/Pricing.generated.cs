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

        [JsonIgnore]
        private double? _price;

        [JsonProperty("price")]
        public virtual double? Price {
            get => _price;
            set {
                var _value = value;
                if (!PriceValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", PriceValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("price",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _price = _value;
            }
        }

        [JsonProperty("taxes")]
        public virtual Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        public Pricing(){}
        public Pricing(Pricing other) {
            Price = other.Price;
            Taxes = other.Taxes;
        }
        public Pricing ToPricing() => new Pricing(this);
    }
}
