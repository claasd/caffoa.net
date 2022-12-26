using Newtonsoft.Json.Converters;

namespace Caffoa.JsonConverter
{
    /// <summary>
    /// custom converter to create date formats.
    /// By default. Newtonsoft-Json only supports DateTime formats.
    /// </summary>
    public class CaffoaDateConverter : IsoDateTimeConverter
    {
        public CaffoaDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}