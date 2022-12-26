using Caffoa;
using DemoV2.Handler;
using DemoV2.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DemoV2.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCaffoaFactory<IDemoV2MaintainanceService, MaintainanceServiceFactory>()
                .AddCaffoaFactory<IDemoV2UserService, UserServiceFactory>()
                .AddCaffoaResultHandler<ResultHandler>();
        }
    }
}