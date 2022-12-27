{IMPORTS}

namespace {NAMESPACE} {{
    {DESCRIPTION}
    public interface {NAME} {{
        [JsonIgnore]
        string {TYPE}Discriminator {{ get; }}
        {NAME} To{NAME}(); 
    }}
}}
