using System.Collections.Immutable;
using System;

namespace {NAMESPACE} {{
    public partial class {CLASS} {{
        public static class {NAMEUPPER}Values {{
            // constant values for "{NAMELOWER}"
            {ENUMS}
    
            /// immutable array containing all allowed values for "{NAMELOWER}"
            public static readonly ImmutableArray<{TYPE}> AllowedValues = ImmutableArray.Create<{TYPE}>({ENUM_NAMES});
        }}
    }}
}}