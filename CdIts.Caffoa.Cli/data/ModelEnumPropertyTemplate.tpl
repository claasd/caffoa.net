        [JsonIgnore]
        private {TYPE} _{NAMELOWER}{DEFAULT}

        {DESCRIPTION}{JSON_EXTRA}[JsonProperty("{NAMELOWER}"{JSON_PROPERTY_EXTRA})]
        public virtual {TYPE} {NAMEUPPER} {{
            get {{
                return _{NAMELOWER};
            }}
            set {{
                {NO_CHECK_MSG}{NO_CHECK}if (!{NAMEUPPER}Values.AllowedValues.Contains(value))
                {NO_CHECK}{{
                {NO_CHECK}    var allowedValues = string.Join(", ", {NAMEUPPER}Values.AllowedValues.Select(v => {NULL_HANDLING}v.ToString()));
                {NO_CHECK}    throw new ArgumentOutOfRangeException("{NAMELOWER}",
                {NO_CHECK}        $"{{value}} is not allowed. Allowed values: [{{allowedValues}}]");
                {NO_CHECK}}}
                _{NAMELOWER} = value;
            }}
        }}