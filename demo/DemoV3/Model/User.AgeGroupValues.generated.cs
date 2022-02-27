using System.Collections.Immutable;
using System;

namespace DemoV3.Model {
    public partial class User {
        public static class AgeGroupValues {
            // constant values for "ageGroup"
            public const int _18 = 18;
            public const int _40 = 40;
            public const int _70 = 70;
            public const int _120 = 120;
    
            /// immutable array containing all allowed values for "ageGroup"
            public static readonly ImmutableArray<int?> AllowedValues = ImmutableArray.Create<int?>(_18, _40, _70, _120, null);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use User.AgeGroupValues._18 instead.")]
        public const int AgeGroup18Value = AgeGroupValues._18;
        [Obsolete("Will be removed in a future version of caffoa. Use User.AgeGroupValues._40 instead.")]
        public const int AgeGroup40Value = AgeGroupValues._40;
        [Obsolete("Will be removed in a future version of caffoa. Use User.AgeGroupValues._70 instead.")]
        public const int AgeGroup70Value = AgeGroupValues._70;
        [Obsolete("Will be removed in a future version of caffoa. Use User.AgeGroupValues._120 instead.")]
        public const int AgeGroup120Value = AgeGroupValues._120;

        [Obsolete("Will be removed in a future version of caffoa. Use User.AgeGroupValues.AllowedValues instead")]
        public static ImmutableArray<int?> AllowedValuesForAgeGroup { get => AgeGroupValues.AllowedValues; }
    }
}