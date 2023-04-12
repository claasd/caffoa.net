using System.Runtime.Serialization;
{IMPORTS}

namespace {NAMESPACE} {{
    [JsonConverter(typeof({JSONPROPERTY}))]
    public enum {ENUMNAME}{ENUMBASE} {{
        {ENUMS}
    }}
}}
