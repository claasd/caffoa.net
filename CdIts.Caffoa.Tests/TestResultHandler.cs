using AwesomeAssertions;
using Caffoa.Defaults;
using CdIts.Caffoa.Tests.TestClasses;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class TestResultHandler
{
    [Test]
    public void EarlyResultHandlerRaisesExceptions()
    {
        var test = new SubData();
        var handler = new CaffoaEarlySerializingResultHandler();
        handler.Invoking(h => h.Result(test, 200, [])).Should().Throw<JsonSerializationException>();
    }
}