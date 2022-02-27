using System;
using System.Threading.Tasks;
using Caffoa;
using DemoV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DemoV3.Services;

public class MaintainanceService : IDemoV3MaintainanceService, ICaffoaFactory<IDemoV3MaintainanceService>
{
    public async Task<LongRunningfunctionStatus> LongRunningFunctionAsync(IDurableOrchestrationClient orchestrationClient, Guid id)
    {
        await Task.Yield();
        return new LongRunningfunctionStatus() { Status = LongRunningfunctionStatus.StatusValues.Running };
    }

    public IDemoV3MaintainanceService Instance(HttpRequest request)
    {
        return this;
    }
}