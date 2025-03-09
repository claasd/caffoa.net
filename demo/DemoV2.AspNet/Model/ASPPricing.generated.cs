#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPPricing : IEquatable<ASPPricing> {
        public const string ASPPricingObjectName = "pricing";
        [JsonPropertyName("price")]
        public double? Price { get; set; }

        [JsonPropertyName("taxes")]
        public Dictionary<string, double> Taxes { get; set; } = new Dictionary<string, double>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPPricing(){}
        public ASPPricing(ASPPricing other) {
            Price = other.Price;
            Taxes = other.Taxes?.ToDictionary(entry => entry.Key, entry => entry.Value);
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPPricing ToASPPricing() => new ASPPricing(this);
        public bool Equals(ASPPricing other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Price == other.Price
                && (other.Taxes is null ? Taxes is null : Taxes?.SequenceEqual(other.Taxes) ?? other.Taxes is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPPricing other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPPricing);
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
