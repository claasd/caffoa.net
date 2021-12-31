using Caffoa;
using Caffoa.Defaults;
using DemoV3.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DemoV3.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICaffoaFactory<IDemoV3Service>, DemoV3Service>();
            builder.Services.AddSingleton<ICaffoaResultHandler>(new DefaultCaffoaResultHandler(
                new JsonSerializerSettings()
                {
                    ContractResolver = new RemoveRequiredContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                }));
        }
    }
}