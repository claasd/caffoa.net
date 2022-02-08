using Caffoa.Defaults;
using Newtonsoft.Json;

namespace DemoV3.Handler;

public class ResultHandler : DefaultCaffoaResultHandler
{
    public ResultHandler() : base(new JsonSerializerSettings()
    {
        ContractResolver = new RemoveRequiredContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Utc
    })
    {
    }
}