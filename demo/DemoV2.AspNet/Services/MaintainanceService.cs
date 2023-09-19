using DemoV2.AspNet.Model;

namespace DemoV2.AspNet.Services;

public class MaintainanceService : IDemoV2AspNetMaintainanceService
{
    public async Task<ASPLongRunningfunctionStatus> LongRunningFunctionAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        return new ASPLongRunningfunctionStatus() { Status = ASPLongRunningfunctionStatus.StatusValue.Running };
    }

    public IDemoV2AspNetMaintainanceService Instance(HttpRequest request)
    {
        return this;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}