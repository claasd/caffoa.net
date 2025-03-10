using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caffoa;
using DemoV2.AspNet.Model.Base;
using DemoV2.AspNet.Model;

namespace DemoV2.AspNet
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV2AspNetMaintainanceService
    {
        /// <summary>
        /// start a long running function via durable functions
        /// 202 -> started long running function
        /// </summary>
        Task<ASPLongRunningfunctionStatus> LongRunningFunctionAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
