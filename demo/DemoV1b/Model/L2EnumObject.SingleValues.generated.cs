using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2EnumObject {
        public static class SingleValues {
            // constant values for "single"
            public const string Enum1 = "enum1";
            public const string Enum2 = "enum2";
            public const string Enum_space = "enum space";
            public const string Enum_sepcial_CHARS = "enum-sepcial_CHARS";
            public const string Deprecated_enum = "deprecated_enum";
    
            /// immutable array containing all allowed values for "single"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Enum1, Enum2, Enum_space, Enum_sepcial_CHARS, Deprecated_enum);
        }
    }
}