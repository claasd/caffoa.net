using System;
using System.Globalization;
using Caffoa.JsonConverter;
using CdIts.Caffoa.Tests.TestClasses;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class TestCustomConverters
{
    [TestCase]
    public void TestDateOnly()
    {
        var elem = new DateOnlyTests();
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyTests>(serialized);
        elem.Date.Should().Be(deserialized!.Date);
    }
    
    [TestCase("2022-11-12")]
    [TestCase("1980-01-01")]
    [TestCase(null)]
    public void TestDateOnlyNullable(string? data)
    {
        var elem = new DateOnlyTestsNullable()
        {
            Date = data == null ? null : DateOnly.Parse(data)
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyTestsNullable>(serialized);
        deserialized!.Date?.ToString(CaffoaDateOnlyConverter.DateFormat).Should().Be(data);
    }
    
    [Test]
    public void TestDateOnlyNonNullable()
    {
        var elem = new DateOnlyTestsNullable()
        {
            Date = null
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTests>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
    
    [TestCase("1.2.22")]
    [TestCase("1. November")]
    [TestCase("WAAS")]
    public void TestDateOnlyNonNullable(string data)
    {
        var serialized = $"{{\"Date\": \"{data}\"}}";
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTests>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
}