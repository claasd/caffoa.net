using System;
using System.Threading.Tasks;
using Caffoa;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DemoV3.Services;

public class MaintainanceService : IDemoV3MaintainanceService, ICaffoaFactory<IDemoV3MaintainanceService>
{
    public Task LongRunningFunctionAsync(IDurableOrchestrationClient orchestrationClient, Guid id)
    {
        return Task.CompletedTask;
    }

    public IDemoV3MaintainanceService Instance(HttpRequest request)
    {
        return this;
    }
}