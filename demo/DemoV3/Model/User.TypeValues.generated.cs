using System.Collections.Immutable;
using System;

namespace DemoV3.Model {
    public partial class User {
        public static class TypeValues {
            // constant values for "type"
            public const string Simple = "simple";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Simple);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use User.TypeValues.Simple instead.")]
        public const string TypeSimpleValue = TypeValues.Simple;

        [Obsolete("Will be removed in a future version of caffoa. Use User.TypeValues.AllowedValues instead")]
        public static ImmutableArray<string> AllowedValuesForType { get => TypeValues.AllowedValues; }
    }
}