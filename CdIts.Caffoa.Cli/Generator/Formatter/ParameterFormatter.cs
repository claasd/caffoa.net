using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public static class ParameterFormatter
{
    public static List<ParameterObject> QueryParameters(this EndPointModel endpoint)
    {
        var queryParameter = endpoint.Parameters.Where(p => p.IsQueryParameter).ToList();
        var orderedParams = queryParameter.Where(p => p.DefaultValue == null && p.Required).ToList();
        orderedParams.AddRange(queryParameter.Where(e => e.DefaultValue != null || !e.Required));
        return orderedParams;
    }
}
