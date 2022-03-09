using Caffoa;
using Microsoft.AspNetCore.Http;

namespace DemoV3.Services;

public class UserServiceFactory : ICaffoaFactory<IDemoV3UserService>
{
    public IDemoV3UserService Instance(HttpRequest request)
    {
        return new DemoV3UserService();
    }
}
