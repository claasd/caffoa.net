using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdIts.AzFuncTestHelper;

public static class Settings
{
    public enum JsonFlavor
    {
        JsonNet,
        SystemTextJson
    }
    public static JsonFlavor DefaultJsonFlavor { get; set; } = JsonFlavor.JsonNet;
    
    public static JsonSerializerOptions JsonOptions { get; set; } = new JsonSerializerOptions
    {
        Converters =
        {
            new JsonStringEnumConverter()
        },
        
    };
}