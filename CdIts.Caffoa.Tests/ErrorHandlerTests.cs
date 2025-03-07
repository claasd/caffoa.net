using System;
using System.Threading;
using Caffoa.Defaults;
using CdIts.AzFuncTestHelper;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class ErrorHandlerTests
{
    [TestCase(true)]
    [TestCase(false)]
    public void TestErrorHandlerOnTimeoutDoesHandleExceptionGracefully(bool canceled)
    {
        var handler = new DefaultCaffoaErrorHandler(NullLogger.Instance, new DefaultCaffoaResultHandler());
        var source = new CancellationTokenSource();
        var token = source.Token;
        if(canceled)
            source.Cancel();
        var request = new RequestBuilder()
            .CancellationToken(token)
            .Build();
        var check = handler.TryHandleFunctionException(new Exception("TEST"), out var result, request, "test", "/route", "OpName");
        check.Should().Be(canceled);
    }
}