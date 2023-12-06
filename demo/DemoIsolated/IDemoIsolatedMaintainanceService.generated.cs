using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DurableTask.Client;
using DemoIsolated.Model.Base;
using DemoIsolated.Model;

namespace DemoIsolated
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoIsolatedMaintainanceService
    {
        /// <summary>
        /// start a long running function via durable functions
        /// 202 -> started long running function
        /// </summary>
        Task<IsoLongRunningfunctionStatus> LongRunningFunctionAsync(DurableTaskClient durableTaskClient, Guid id, CancellationToken cancellationToken = default);

    }
}