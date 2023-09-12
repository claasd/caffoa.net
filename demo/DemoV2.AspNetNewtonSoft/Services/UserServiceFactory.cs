using Caffoa;

namespace DemoV2.AspNetNewtonSoft.Services;

public class UserServiceFactory : ICaffoaFactory<IDemoV2AspNetNewtonSoftUserService>
{
    public IDemoV2AspNetNewtonSoftUserService Instance(HttpRequest request)
    {
        return new DemoV2UserService();
    }
}