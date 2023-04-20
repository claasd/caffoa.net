using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2EnumObject {
        public static class NullableReferencedValues {
            // constant values for "nullableReferenced"
            public const string First = "first";
            public const string Second = "second";
    
            /// immutable array containing all allowed values for "nullableReferenced"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(First, Second, null);
        }
    }
}