using System.Runtime.Serialization;
using Caffoa.JsonConverter;
{IMPORTS}

namespace {NAMESPACE} {{
    [JsonConverter(typeof({JSONPROPERTY}))]
    public enum {ENUMNAME}{ENUMBASE} {{
        {ENUMS}
    }}
}}
