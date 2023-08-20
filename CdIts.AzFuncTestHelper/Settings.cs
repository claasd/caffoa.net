using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CdIts.AzFuncTestHelper;

public static class Settings
{
    public enum JsonFlavor
    {
        JsonNet,
        SystemTextJson
    }
    public static JsonFlavor DefaultJsonFlavor { get; set; } = JsonFlavor.JsonNet;
    public static JsonSerializerSettings JsonSettings { get; set; } = new JsonSerializerSettings();
    public static JsonSerializerOptions JsonOptions { get; set; } = new JsonSerializerOptions
    {
        Converters =
        {
            new JsonStringEnumConverter()
        },
        
    };
}