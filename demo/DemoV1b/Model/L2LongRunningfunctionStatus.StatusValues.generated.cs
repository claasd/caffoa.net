using System.Collections.Immutable;
using System;

namespace DemoV1b.Model {
    public partial class L2LongRunningfunctionStatus {
        public static class StatusValues {
            // constant values for "status"
            public const string Running = "running";
            public const string Success = "success";
            public const string Failure = "failure";
    
            /// immutable array containing all allowed values for "status"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Running, Success, Failure, null);
        }
    }
}