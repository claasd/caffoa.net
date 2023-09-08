using Caffoa;

namespace DemoV2.AspNet.Services;

public class UserServiceFactory : ICaffoaFactory<IDemoV2AspNetUserService>
{
    public IDemoV2AspNetUserService Instance(HttpRequest request)
    {
        return new DemoV2UserService();
    }
}