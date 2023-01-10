using System.Collections.Immutable;
using System;

namespace DemoV1a.Model {
    public partial class L1EnumObject {
        public static class WithDefaultValues {
            // constant values for "withDefault"
            public const string True = "true";
            public const string False = "false";
            public const string Undefined = "undefined";
    
            /// immutable array containing all allowed values for "withDefault"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(True, False, Undefined);
        }
    }
}