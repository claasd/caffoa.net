        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWith{OTHER}(this {NAME} item, {OTHER} other, bool deepClone = true) {{
            {UPDATEPROPS}
        }}
        
        /// <summary>
        /// Returns a new object of {OTHER} with fileds filled from {NAME}. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static {OTHER} To{OTHER}(this {NAME} other, bool deepClone = true) => new {OTHER}() {{ 
            {INITPROPS}
        }};