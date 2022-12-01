        [JsonIgnore]
        private {TYPE} _{NAMELOWER}{DEFAULT}

        {DESCRIPTION}{JSON_EXTRA}[JsonProperty("{NAMELOWER}"{JSON_PROPERTY_EXTRA})]
        public virtual {TYPE} {NAMEUPPER} {{
            get => _{NAMELOWER};
            set {{
                var _value = {TRANSFORM};
                _{NAMELOWER} = _value;
            }}
        }}