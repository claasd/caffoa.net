using Caffoa;
using DemoV2.Text.Json;
using Microsoft.AspNetCore.Http;

namespace DemoV2.Services;

public class UserServiceFactory : ICaffoaFactory<IDemoV2TextJsonUserService>
{
    public IDemoV2TextJsonUserService Instance(HttpRequest request)
    {
        return new DemoV2UserService();
    }
}