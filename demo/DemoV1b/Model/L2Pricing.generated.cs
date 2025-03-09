#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class L2Pricing : IEquatable<L2Pricing> {
        public const string L2PricingObjectName = "pricing";
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("taxes")]
        public Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2Pricing(){}
        public L2Pricing(L2Pricing other) {
            Price = other.Price;
            Taxes = other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2Pricing ToL2Pricing() => new L2Pricing(this);
        public bool Equals(L2Pricing other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Price == other.Price
                && (other.Taxes is null ? Taxes is null : Taxes?.SequenceEqual(other.Taxes) ?? other.Taxes is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2Pricing other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2Pricing);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Price);
            hashCode.Add(Taxes);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
