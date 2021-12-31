        // constant values for "{NAMELOWER}"
        {ENUMS}

        /// <summary>
        /// immutable array containing all allowed values for "{NAMELOWER}"
        /// </summary>
        public static readonly ImmutableArray<{TYPE}> {ENUM_LIST_NAME} = ImmutableArray.Create<{TYPE}>({ENUM_NAMES});

        [JsonIgnore]
        private {TYPE} _{NAMELOWER}{DEFAULT}

        {DESCRIPTION}{JSON_EXTRA}[JsonProperty("{NAMELOWER}"{JSON_PROPERTY_EXTRA})]
        public virtual {TYPE} {NAMEUPPER} {{
            get {{
                return _{NAMELOWER};
            }}
            set {{
                {NO_CHECK_MSG}{NO_CHECK}if (!{ENUM_LIST_NAME}.Contains(value))
                {NO_CHECK}{{
                {NO_CHECK}    var allowedValues = string.Join(", ", {ENUM_LIST_NAME}.Select(v => {NULL_HANDLING}v.ToString()));
                {NO_CHECK}    throw new ArgumentOutOfRangeException("{NAMELOWER}",
                {NO_CHECK}        $"{{value}} is not allowed. Allowed values: [{{allowedValues}}]");
                {NO_CHECK}}}
                _{NAMELOWER} = value;
            }}
        }}