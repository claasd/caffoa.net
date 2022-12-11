using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using DemoV1b.Model.Base;
using DemoV1b.Model;

namespace DemoV1b
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV1bMaintainanceService
    {
        /// <summary>
        /// start a long running function via durable functions
        /// 202 -> started long running function
        /// </summary>
        Task<L2LongRunningfunctionStatus> LongRunningFunctionAsync(IDurableOrchestrationClient orchestrationClient, Guid id, CancellationToken cancellationToken = default);

    }
}
