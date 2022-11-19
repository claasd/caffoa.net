using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace {NAMESPACE} {{
    public partial class {CLASS} {{
        // enum values for "{NAMELOWER}"
        [JsonConverter(typeof({JSONPROPERTY}))]
        public enum {ENUMNAME}{ENUMBASE} {{
            {ENUMS}
        }}
    }}
}}