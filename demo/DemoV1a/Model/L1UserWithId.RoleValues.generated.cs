using System.Collections.Immutable;
using System;

namespace DemoV1a.Model {
    public partial class L1UserWithId {
        public static class RoleValues {
            // constant values for "role"
            public const string Admin = "admin";
            public const string Reader = "reader";
            public const string Contributor = "contributor";
    
            /// immutable array containing all allowed values for "role"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Admin, Reader, Contributor);
        }
    }
}