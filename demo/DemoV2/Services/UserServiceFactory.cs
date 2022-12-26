using Caffoa;
using Microsoft.AspNetCore.Http;

namespace DemoV2.Services;

public class UserServiceFactory : ICaffoaFactory<IDemoV2UserService>
{
    public IDemoV2UserService Instance(HttpRequest request)
    {
        return new DemoV2UserService();
    }
}