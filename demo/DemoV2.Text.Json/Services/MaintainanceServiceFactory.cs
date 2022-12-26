using Caffoa;
using DemoV2.Text.Json;
using Microsoft.AspNetCore.Http;

namespace DemoV2.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV2TextJsonMaintainanceService>
{
    public IDemoV2TextJsonMaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}