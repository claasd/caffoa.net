using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
{IMPORTS}
namespace {NAMESPACE} {{
    {DESCRIPTION}[JsonObject(MemberSerialization.OptIn)]
    public partial class {NAME}{PARENTS} {{
        public const string {NAME}ObjectName = "{RAWNAME}";
{PROPERTIES}

        public {NAME} To{NAME}() {{
            var item = new {NAME}();
            item.UpdateWith{NAME}(this);
            return item;
        }}

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWith{NAME}({NAME} other) {{
            {UPDATEPROPS}
        }}

        /// <summary>
        /// Merges all fields of {NAME} that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWith{NAME}({NAME} other, JsonMergeSettings mergeSettings = null) {{
            MergeWith{NAME}(JObject.FromObject(other), mergeSettings);
        }}

        /// <summary>
        /// Merges all fields of {NAME} that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWith{NAME}(JToken other, JsonMergeSettings mergeSettings = null) {{
            mergeSettings ??= new JsonMergeSettings()
            {{
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            }};
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWith{NAME}(sourceObject.ToObject<{NAME}>());
        }}
    }}
}}
