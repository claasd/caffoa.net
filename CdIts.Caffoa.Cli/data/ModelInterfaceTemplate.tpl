{IMPORTS}

namespace {NAMESPACE} {{
    {DESCRIPTION}{ATTRIBUTES}
    public interface {NAME} {{
        [JsonIgnore]
        string {TYPE}Discriminator {{ get; }}
        {NAME} To{NAME}();
    }}
}}
