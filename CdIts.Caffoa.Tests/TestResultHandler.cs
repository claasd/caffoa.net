using Caffoa.Defaults;
using CdIts.Caffoa.Tests.TestClasses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        handler.Invoking(h=>h.Json(test, 200)).Should().Throw<JsonSerializationException>();
    }
    
    [Test]
    public void CheckUnwantedBehavoirUsingDefaultResultHandler()
    {
        var test = new SubData();
        var result = new DefaultCaffoaResultHandler().Json(test, 200);
        result.Should().BeOfType(typeof(JsonResult));
        // no exception thrown, but the data would throw an exception when serialized
        
        var act = () => JsonConvert.SerializeObject((result as JsonResult)!.Value);
        act.Should().Throw<JsonSerializationException>();
    }
}