#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public partial class STJPricing {
        public const string STJPricingObjectName = "pricing";

        [JsonPropertyName("price")]
        public virtual double? Price { get; set; }

        [JsonPropertyName("taxes")]
        public virtual Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJPricing(){}
        public STJPricing(STJPricing other) {
            Price = other.Price;
            Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJPricing ToSTJPricing() => new STJPricing(this);
    }
}
