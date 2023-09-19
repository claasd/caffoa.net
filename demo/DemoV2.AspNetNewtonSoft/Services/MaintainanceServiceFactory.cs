using Caffoa;

namespace DemoV2.AspNetNewtonSoft.Services;

public class MaintainanceServiceFactory : ICaffoaFactory<IDemoV2AspNetNewtonSoftMaintainanceService>
{
    public IDemoV2AspNetNewtonSoftMaintainanceService Instance(HttpRequest request)
    {
        return new MaintainanceService();
    }
}