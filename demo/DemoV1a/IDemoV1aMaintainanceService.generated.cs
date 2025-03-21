using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caffoa;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using DemoV1a.Model.Base;
using DemoV1a.Model;

namespace DemoV1a
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV1aMaintainanceService
    {
        /// <summary>
        /// start a long running function via durable functions
        /// 202 -> started long running function
        /// </summary>
        Task<L1LongRunningfunctionStatus> LongRunningFunctionAsync(IDurableOrchestrationClient orchestrationClient, Guid id, CancellationToken cancellationToken = default);

    }
}
