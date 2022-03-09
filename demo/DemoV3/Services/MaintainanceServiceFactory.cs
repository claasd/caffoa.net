using Caffoa;
using Microsoft.AspNetCore.Http;

namespace DemoV3.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV3MaintainanceService>
{
    public IDemoV3MaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}
