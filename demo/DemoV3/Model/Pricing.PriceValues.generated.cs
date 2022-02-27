using System.Collections.Immutable;
using System;

namespace DemoV3.Model {
    public partial class Pricing {
        public static class PriceValues {
            // constant values for "price"
            public const double _32_99 = 32.99;
            public const double _33_99 = 33.99;
            public const double _44_99 = 44.99;
    
            /// immutable array containing all allowed values for "price"
            public static readonly ImmutableArray<double?> AllowedValues = ImmutableArray.Create<double?>(_32_99, _33_99, _44_99, null);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use Pricing.PriceValues._32_99 instead.")]
        public const double Price32_99Value = PriceValues._32_99;
        [Obsolete("Will be removed in a future version of caffoa. Use Pricing.PriceValues._33_99 instead.")]
        public const double Price33_99Value = PriceValues._33_99;
        [Obsolete("Will be removed in a future version of caffoa. Use Pricing.PriceValues._44_99 instead.")]
        public const double Price44_99Value = PriceValues._44_99;

        [Obsolete("Will be removed in a future version of caffoa. Use Pricing.PriceValues.AllowedValues instead")]
        public static ImmutableArray<double?> AllowedValuesForPrice { get => PriceValues.AllowedValues; }
    }
}