using Caffoa;
using Microsoft.AspNetCore.Http;

namespace DemoV2.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV2MaintainanceService>
{
    public IDemoV2MaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}