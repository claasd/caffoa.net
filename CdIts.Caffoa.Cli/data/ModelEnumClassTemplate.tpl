using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace {NAMESPACE} {{
    [JsonConverter(typeof({JSONPROPERTY}))]
    public enum {ENUMNAME}{ENUMBASE} {{
        {ENUMS}
    }}
}}
