using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Config;

public class FilterConfig
{
    public List<string>? Operations { get; set; }
    public List<string>? Methods { get; set; }
    public bool? All { get; set; }
    public string? Prefix { get; set; }

    public bool Contains(OperationType type, OpenApiOperation operation)
    {
        return All is true
               || (Prefix != null && operation.OperationId.StartsWith(Prefix))
               || (Methods != null && Methods.Contains(type.ToString().ToLower()))
               || (Operations != null && Operations.Contains(operation.OperationId));
    }
}
