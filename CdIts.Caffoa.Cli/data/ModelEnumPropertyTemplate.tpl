        [JsonIgnore]
        private {TYPE} _{NAMELOWER}{DEFAULT}

        {DESCRIPTION}{JSON_EXTRA}[{JSON_TAG_NAME}("{NAMELOWER}"{JSON_PROPERTY_EXTRA})]
        public{VIRTUAL} {TYPE} {NAMEUPPER} {{
            get => _{NAMELOWER};
            set {{
                var _value = {TRANSFORM};
                {NO_CHECK_MSG}{NO_CHECK}if (!{NAMEUPPER}Values.AllowedValues.Contains(_value))
                {NO_CHECK}{{
                {NO_CHECK}    var allowedValues = string.Join(", ", {NAMEUPPER}Values.AllowedValues.Select(v => {NULL_HANDLING}v.ToString()));
                {NO_CHECK}    throw new ArgumentOutOfRangeException("{NAMELOWER}",
                {NO_CHECK}        $"{{value}} is not allowed. Allowed values: [{{allowedValues}}]");
                {NO_CHECK}}}
                _{NAMELOWER} = _value;
            }}
        }}