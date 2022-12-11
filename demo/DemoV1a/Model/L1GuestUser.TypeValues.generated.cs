using System.Collections.Immutable;
using System;

namespace DemoV1a.Model {
    public partial class L1GuestUser {
        public static class TypeValues {
            // constant values for "type"
            public const string Guest = "guest";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Guest);
        }
    }
}