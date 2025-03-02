using System.Runtime.Serialization;
using Caffoa;
using Caffoa.JsonConverter;
{IMPORTS}

namespace {NAMESPACE} {{
    public partial class {CLASS} {{
        // enum values for "{NAMELOWER}"
        [JsonConverter(typeof({JSONPROPERTY}))]
        public enum {ENUMNAME}{ENUMBASE} {{
            {ENUMS}
        }}
        [JsonConverter(typeof(CaffoaEnumWrapperConverter<{ENUMNAME}Wrapper>))]
        public partial class {ENUMNAME}Wrapper : CaffoaEnumWrapper<{ENUMNAME}>
        {{
            public {ENUMNAME}Wrapper() : base() {{}}
            public {ENUMNAME}Wrapper({ENUMNAME} value) : base(value) {{}}
            public {ENUMNAME}Wrapper(string value) : base(value) {{}}
            public static implicit operator {ENUMNAME}Wrapper({ENUMNAME} value) => new {ENUMNAME}Wrapper(value);
        }}
    }}
    
}}