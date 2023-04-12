using System.Runtime.Serialization;
{IMPORTS}

namespace {NAMESPACE} {{
    public partial class {CLASS} {{
        // enum values for "{NAMELOWER}"
        [JsonConverter(typeof({JSONPROPERTY}))]
        public enum {ENUMNAME}{ENUMBASE} {{
            {ENUMS}
        }}
    }}
}}