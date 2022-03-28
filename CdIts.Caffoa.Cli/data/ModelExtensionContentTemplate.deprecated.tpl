        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWith{OTHER}(this {NAME} item, {OTHER} other) {{
            {UPDATEPROPS}
        }}

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWith{OTHER}(this {NAME} item, {OTHER} other, JsonMergeSettings mergeSettings = null) {{
            item.MergeWith{OTHER}(JObject.FromObject(other), mergeSettings);
        }}

        [Obsolete("Use MergedWith<T> from Caffoa.Extensions instead")]
        public static void MergeWith{OTHER}(this {NAME} item, JToken other, JsonMergeSettings mergeSettings = null) {{
            mergeSettings ??= new JsonMergeSettings()
            {{
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            }};
            var sourceObject = JObject.FromObject(item);
            sourceObject.Merge(other, mergeSettings);
            item.UpdateWith{OTHER}(sourceObject.ToObject<{OTHER}>());
        }}