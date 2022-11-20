using System;
using System.Threading.Tasks;
using DemoV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DemoV3.Services;

public class MaintainanceService : IDemoV3MaintainanceService
{
    public async Task<LongRunningfunctionStatus> LongRunningFunctionAsync(IDurableOrchestrationClient orchestrationClient, Guid id)
    {
        await Task.Yield();
        return new LongRunningfunctionStatus() { Status = LongRunningfunctionStatus.StatusValue.Running };
    }

    public IDemoV3MaintainanceService Instance(HttpRequest request)
    {
        return this;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}