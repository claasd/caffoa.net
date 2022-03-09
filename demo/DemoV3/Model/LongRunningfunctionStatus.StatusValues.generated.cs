using System.Collections.Immutable;
using System;

namespace DemoV3.Model {
    public partial class LongRunningfunctionStatus {
        public static class StatusValues {
            // constant values for "status"
            public const string Running = "running";
            public const string Success = "success";
            public const string Failure = "failure";
    
            /// immutable array containing all allowed values for "status"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Running, Success, Failure);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use LongRunningfunctionStatus.StatusValues.Running instead.")]
        public const string StatusRunningValue = StatusValues.Running;
        [Obsolete("Will be removed in a future version of caffoa. Use LongRunningfunctionStatus.StatusValues.Success instead.")]
        public const string StatusSuccessValue = StatusValues.Success;
        [Obsolete("Will be removed in a future version of caffoa. Use LongRunningfunctionStatus.StatusValues.Failure instead.")]
        public const string StatusFailureValue = StatusValues.Failure;

        [Obsolete("Will be removed in a future version of caffoa. Use LongRunningfunctionStatus.StatusValues.AllowedValues instead")]
        public static ImmutableArray<string> AllowedValuesForStatus { get => StatusValues.AllowedValues; }
    }
}