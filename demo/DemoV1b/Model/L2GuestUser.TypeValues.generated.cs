using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2GuestUser {
        public static class TypeValues {
            // constant values for "type"
            public const string Guest = "guest";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Guest);
        }
    }
}