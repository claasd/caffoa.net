using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1Pricing {
        public const string L1PricingObjectName = "pricing";

        [JsonProperty("price")]
        public virtual double? Price { get; set; }

        [JsonProperty("taxes")]
        public virtual Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        public L1Pricing(){}
        public L1Pricing(L1Pricing other) {
            Price = other.Price;
            Taxes = other.Taxes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public L1Pricing ToL1Pricing() => new L1Pricing(this);
    }
}
