using AwesomeAssertions;
using Caffoa;
using Caffoa.Defaults;
using Caffoa.Extensions;
using CdIts.Caffoa.Tests.TestClasses;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class TestExtensions
{
    [Test]
    public void TestMergedSimple()
    {
        var a = new Ext1Data()
        {
            D1 = "D1a",
            D2 = "D2a"
        };
        var b = new BaseData()
        {
            D1 = "D1b"
        };
        var c = a.MergedWith(b);
        c.D1.Should().Be("D1b");
        c.D2.Should().Be("D2a");
    }

    [Test]
    public void TestMergedWithJObject()
    {
        var a = new Ext1Data()
        {
            D1 = "D1a",
            D2 = "D2a"
        };
        var b = new JObject()
        {
            ["D1"] = "D1b",
            ["D2"] = "D2b"
        };
        var c = a.MergedWith<BaseData, Ext1Data>(b);
        c.D1.Should().Be("D1b");
        c.D2.Should().Be("D2a");
    }
    
    [Test]
    public void TestMergedWithJObjectWithoutSpec()
    {
        var a = new Ext1Data()
        {
            D1 = "D1a",
            D2 = "D2a"
        };
        var b = new JObject()
        {
            ["D1"] = "D1b",
            ["D2"] = "D2b"
        };
        var c = a.MergedWith(b);
        c.D1.Should().Be("D1b");
        c.D2.Should().Be("D2b");
    }
    
    [Test]
    public void TestErrorHandlingWithInvalidFieldsInBase()
    {
        var a = new BaseData()
        {
            D1 = null,
        };
        var b = new JObject()
        {
            ["D1"] = "data"
        };
        var errorHandler = new DefaultCaffoaErrorHandler(NullLogger.Instance, new DefaultCaffoaResultHandler());
        a.Invoking(d => d.MergedWith(b)).Should().Throw<JsonSerializationException>();
        a.Invoking(d => d.MergedWith(b, errorHandler: errorHandler)).Should().Throw<CaffoaClientError>();
    }
    
    [Test]
    public void TestErrorHandlingWithInvalidFieldsInTarget()
    {
        var a = new BaseData()
        {
            D1 = "D1",
        };
        var b = new BaseData()
        {
            D1 = null,
        };
        var errorHandler = new DefaultCaffoaErrorHandler(NullLogger.Instance, new DefaultCaffoaResultHandler());
        a.Invoking(d => d.MergedWith(b)).Should().Throw<JsonSerializationException>();
        a.Invoking(d => d.MergedWith(b, errorHandler: errorHandler)).Should().Throw<CaffoaClientError>();
    }
    
    [Test]
    public void TestErrorHandlingWithMissingFieldsDuringMerge()
    {
        var a = new BaseData()
        {
            D1 = "D1a",
        };
        var b = new JObject()
        {
            ["D1"] = "D1b",
            ["sub"] = JObject.Parse("{}")
        };
        var errorHandler = new DefaultCaffoaErrorHandler(NullLogger.Instance, new DefaultCaffoaResultHandler());
        a.Invoking(d => d.MergedWith(b)).Should().Throw<JsonSerializationException>();
        a.Invoking(d => d.MergedWith(b, errorHandler: errorHandler)).Should().Throw<CaffoaClientError>();
    }
    
    [Test]
    public void TestErrorHandlingWithInvalidFieldsAfterMerge()
    {
        var a = new BaseData()
        {
            D1 = "D1a",
        };
        var b = new JObject()
        {
            ["D1"] = null
        };
        var errorHandler = new DefaultCaffoaErrorHandler(NullLogger.Instance, new DefaultCaffoaResultHandler());
        a.Invoking(d => d.MergedWith(b)).Should().Throw<JsonSerializationException>();
        a.Invoking(d => d.MergedWith(b, errorHandler: errorHandler)).Should().Throw<CaffoaClientError>();
    }
}
