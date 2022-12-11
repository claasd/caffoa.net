using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2User {
        public static class AgeGroupValues {
            // constant values for "ageGroup"
            public const int _18 = 18;
            public const int _40 = 40;
            public const int _70 = 70;
            public const int _120 = 120;
    
            /// immutable array containing all allowed values for "ageGroup"
            public static readonly ImmutableArray<int?> AllowedValues = ImmutableArray.Create<int?>(_18, _40, _70, _120, null);
        }
    }
}