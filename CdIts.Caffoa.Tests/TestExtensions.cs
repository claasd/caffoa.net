using Caffoa.Extensions;
using CdIts.Caffoa.Tests.TestClasses;
using FluentAssertions;
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
}
