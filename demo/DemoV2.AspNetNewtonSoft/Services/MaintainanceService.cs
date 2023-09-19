using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft.Services;

public class MaintainanceService : IDemoV2AspNetNewtonSoftMaintainanceService
{
    public async Task<ASPNLongRunningfunctionStatus> LongRunningFunctionAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        return new ASPNLongRunningfunctionStatus() { Status = ASPNLongRunningfunctionStatus.StatusValue.Running };
    }

    public IDemoV2AspNetNewtonSoftMaintainanceService Instance(HttpRequest request)
    {
        return this;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}