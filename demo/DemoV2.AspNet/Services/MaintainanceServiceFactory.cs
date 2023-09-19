using Caffoa;

namespace DemoV2.AspNet.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV2AspNetMaintainanceService>
{
    public IDemoV2AspNetMaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}