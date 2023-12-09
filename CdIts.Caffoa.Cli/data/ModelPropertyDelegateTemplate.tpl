        {DESCRIPTION}{JSON_EXTRA}[{JSON_TAG_NAME}("{NAMELOWER}"{JSON_PROPERTY_EXTRA})]{JSON_EXTRA_PROPERTIES}
        public{VIRTUAL} {TYPE} {NAMEUPPER} {{ 
            get => Get{NAMEUPPER}(); 
            set => Set{NAMEUPPER}(value);
        }}
        public partial {TYPE} Get{NAMEUPPER}();
        partial void Set{NAMEUPPER}({TYPE} value);