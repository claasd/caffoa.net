using System.Reflection.Metadata;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace CdIts.Caffoa.Cli.Generator;

public static class OpenApiFileGenerator
{
    public static void WriteGeneratedApiFile(OpenApiDocument doc, string apiPath, bool simplify)
    {
        if (simplify)
            doc = Simplify(doc);
        var path = Path.ChangeExtension(apiPath, "generated.yml");
        using var fileStream = File.Create(path);
        doc.Serialize(fileStream, OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Yaml, new OpenApiWriterSettings()
        {
            InlineExternalReferences = true,
            InlineLocalReferences = true
        });
    }

    private static OpenApiDocument Simplify(OpenApiDocument doc)
    {
        doc.SecurityRequirements.Clear();
        foreach (var apiPath in doc.Paths.Values)
        {
            foreach (var operation in apiPath.Operations.Values)
            {
                SimplifyRequestBody(operation, doc);
                SimplifyResponses(operation, doc);
            }
        }
        return doc;
    }

    private static void SimplifyResponses(OpenApiOperation operation, OpenApiDocument doc)
    {
        foreach (var responseId in operation.Responses.Keys)
        {
            var response = operation.Responses[responseId];
            if (response.UnresolvedReference && doc.Workspace.ResolveReference(response.Reference) is OpenApiResponse reference)
            {
                operation.Responses[responseId] = response = new OpenApiResponse(reference)
                {
                    Reference = null,
                    UnresolvedReference = false
                };
            }

            foreach (var element in response.Content)
            {
                element.Value.Schema = null;
            }
        }
    }

    private static void SimplifyRequestBody(OpenApiOperation operation, OpenApiDocument doc)
    {
        if (operation.RequestBody == null) return;
        if (operation.RequestBody.UnresolvedReference &&
            doc.Workspace.ResolveReference(operation.RequestBody.Reference) is OpenApiRequestBody reference)
            operation.RequestBody = new OpenApiRequestBody(reference)
            {
                Reference = null,
                UnresolvedReference = false
            };
        foreach (var element in operation.RequestBody.Content)
        {
            element.Value.Schema = null;
        }
    }
}