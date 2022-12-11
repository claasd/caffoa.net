using System.Collections.Immutable;
using System;

namespace DemoV1a.Model {
    public partial class L1UserWithId {
        public static class TypeValues {
            // constant values for "type"
            public const string Simple = "simple";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Simple);
        }
    }
}