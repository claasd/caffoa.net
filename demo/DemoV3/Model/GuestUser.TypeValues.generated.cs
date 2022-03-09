using System.Collections.Immutable;
using System;

namespace DemoV3.Model {
    public partial class GuestUser {
        public static class TypeValues {
            // constant values for "type"
            public const string Guest = "guest";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Guest);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use GuestUser.TypeValues.Guest instead.")]
        public const string TypeGuestValue = TypeValues.Guest;

        [Obsolete("Will be removed in a future version of caffoa. Use GuestUser.TypeValues.AllowedValues instead")]
        public static ImmutableArray<string> AllowedValuesForType { get => TypeValues.AllowedValues; }
    }
}