#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class IsoPricing : IEquatable<IsoPricing> {
        public const string IsoPricingObjectName = "pricing";
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("taxes")]
        public Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoPricing(){}
        public IsoPricing(IsoPricing other) {
            Price = other.Price;
            Taxes = other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoPricing ToIsoPricing() => new IsoPricing(this);
        public bool Equals(IsoPricing other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Price == other.Price
                && (other.Taxes is null ? Taxes is null : Taxes?.SequenceEqual(other.Taxes) ?? other.Taxes is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IsoPricing other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IsoPricing);
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
