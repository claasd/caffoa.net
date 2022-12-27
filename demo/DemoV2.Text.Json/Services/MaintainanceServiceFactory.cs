using Caffoa;
using Microsoft.AspNetCore.Http;

namespace DemoV2.Text.Json.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV2TextJsonMaintainanceService>
{
    public IDemoV2TextJsonMaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}