using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2UserWithId {
        public static class RoleValues {
            // constant values for "role"
            public const string Admin = "admin";
            public const string Reader = "reader";
            public const string Contributor = "contributor";
            public const string Editor = "editor";
    
            /// immutable array containing all allowed values for "role"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Admin, Reader, Contributor, Editor);
        }
    }
}