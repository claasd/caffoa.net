using System.Collections.Immutable;
using System;

namespace DemoV1a.Model {
    public partial class L1EnumObject {
        public static class NullableReferencedValues {
            // constant values for "nullableReferenced"
            public const string First = "first";
            public const string Second = "second";
    
            /// immutable array containing all allowed values for "nullableReferenced"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(First, Second, null);
        }
    }
}