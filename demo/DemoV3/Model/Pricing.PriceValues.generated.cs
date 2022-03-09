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
    }
}