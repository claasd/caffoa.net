using Caffoa;
using DemoV2.Services;
using DemoV2.Text.Json.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DemoV2.Text.Json.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCaffoaFactory<IDemoV2TextJsonMaintainanceService, MaintainanceServiceFactory>()
                .AddCaffoaFactory<IDemoV2TextJsonUserService, UserServiceFactory>();
        }
    }
}