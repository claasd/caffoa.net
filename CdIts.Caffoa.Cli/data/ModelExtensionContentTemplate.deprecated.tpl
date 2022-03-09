        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWith{NAME}(this {NAME} item, {NAME} other) {{
            {UPDATEPROPS}
        }}

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWith{NAME}(this {NAME} item, {NAME} other, JsonMergeSettings mergeSettings = null) {{
            item.MergeWith{NAME}(JObject.FromObject(other), mergeSettings);
        }}

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWith{NAME}(this {NAME} item, JToken other, JsonMergeSettings mergeSettings = null) {{
            mergeSettings ??= new JsonMergeSettings()
            {{
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            }};
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWith{NAME}(sourceObject.ToObject<{NAME}>());
        }}