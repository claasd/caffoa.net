using System.Collections.Immutable;
using System;

namespace DemoV1a.Model.Base {
    public partial class L1Address {
        public static class AddressTypeValues {
            // constant values for "addressType"
            public const string Regular = "regular";
    
            /// immutable array containing all allowed values for "addressType"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Regular);
        }
    }
}