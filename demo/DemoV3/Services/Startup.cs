using Caffoa;
using DemoV3.Handler;
using DemoV3.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DemoV3.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICaffoaFactory<IDemoV3MaintainanceService>, MaintainanceService>();
            builder.Services.AddSingleton<ICaffoaFactory<IDemoV3UserService>, DemoV3UserService>();
            builder.Services.AddScoped<ICaffoaResultHandler, ResultHandler>();
        }
    }
}