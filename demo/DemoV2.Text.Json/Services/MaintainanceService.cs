using System;
using System.Threading;
using System.Threading.Tasks;
using DemoV2.Text.Json.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DemoV2.Text.Json.Services;

public class MaintainanceService : IDemoV2TextJsonMaintainanceService
{
    public async Task<STJLongRunningfunctionStatus> LongRunningFunctionAsync(
        IDurableOrchestrationClient orchestrationClient, Guid id, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        return new STJLongRunningfunctionStatus() { Status = STJLongRunningfunctionStatus.StatusValue.Running };
    }

    public IDemoV2TextJsonMaintainanceService Instance(HttpRequest request)
    {
        return this;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}