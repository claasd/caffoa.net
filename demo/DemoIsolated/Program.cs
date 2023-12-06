// See https://aka.ms/new-console-template for more information

using Caffoa;
using DemoIsolated;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(s => { s.AddCaffoaFactory<IDemoIsolatedUserService, IsolatedUserService>(); })
    .Build();

await host.RunAsync();