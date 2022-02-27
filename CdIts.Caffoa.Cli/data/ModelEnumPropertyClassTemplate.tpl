        public static class {NAMEUPPER}Values {{
            // constant values for "{NAMELOWER}"
            {ENUMS}
    
            /// immutable array containing all allowed values for "{NAMELOWER}"
            public static readonly ImmutableArray<{TYPE}> AllowedValues = ImmutableArray.Create<{TYPE}>({ENUM_NAMES});
        }}
        
        {OBSOLETE_ENUMS}

        [Obsolete("Will be removed in a future version of caffoa. Use {NAMEUPPER}Values.AllowedValues instead")]
        public static ImmutableArray<{TYPE}> {OBSOLETE_LIST_NAME} {{ get => {NAMEUPPER}Values.AllowedValues; }}