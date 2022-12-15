using System.Collections.Immutable;
using System;

namespace DemoV1b.Model.Base {
    public partial class L2Address {
        public static class AddressTypeValues {
            // constant values for "addressType"
            public const string Regular = "regular";
    
            /// immutable array containing all allowed values for "addressType"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Regular);
        }
    }
}