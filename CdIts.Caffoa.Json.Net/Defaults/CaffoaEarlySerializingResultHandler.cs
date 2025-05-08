using Newtonsoft.Json;

namespace Caffoa.Defaults;

[Obsolete("This class is deprecated. Use DefaultCaffoaResultHandler instead. DefaultCaffoaResultHandler now uses early serialization by default.")]
public class CaffoaEarlySerializingResultHandler : DefaultCaffoaResultHandler
{
    public CaffoaEarlySerializingResultHandler()
    {
    }

    public CaffoaEarlySerializingResultHandler(JsonSerializerSettings serializerSettings) : base(serializerSettings)
    {
    }
}