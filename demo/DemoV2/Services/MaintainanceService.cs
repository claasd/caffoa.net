using System;
using System.Threading;
using System.Threading.Tasks;
using DemoV2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DemoV2.Services;

public class MaintainanceService : IDemoV2MaintainanceService
{
    public async Task<LongRunningfunctionStatus> LongRunningFunctionAsync(
        IDurableOrchestrationClient orchestrationClient, Guid id, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        return new LongRunningfunctionStatus() { Status = LongRunningfunctionStatus.StatusValue.Running };
    }

    public IDemoV2MaintainanceService Instance(HttpRequest request)
    {
        return this;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}