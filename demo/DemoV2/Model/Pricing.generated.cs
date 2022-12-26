#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Pricing {
        public const string PricingObjectName = "pricing";

        [JsonProperty("price")]
        public virtual double? Price { get; set; }

        [JsonProperty("taxes")]
        public virtual Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public Pricing(){}
        public Pricing(Pricing other) {
            Price = other.Price;
            Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public Pricing ToPricing() => new Pricing(this);
    }
}
