using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2EnumObject {
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