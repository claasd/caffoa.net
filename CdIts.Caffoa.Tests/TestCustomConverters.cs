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
    [Test]
    public void TestDateOnlyRoundtrip()
    {
        var elem = new DateOnlyTestObject();
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        elem.Date.Should().Be(deserialized!.Date);
    }
    
    
    [TestCase("2022-11-12")]
    [TestCase("1980-01-01")]
    [TestCase(null)]
    public void TestDateOnlyNullable(string? data)
    {
        var elem = new DateOnlyNullableTestObject()
        {
            Date = data == null ? null : DateOnly.Parse(data)
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyNullableTestObject>(serialized);
        deserialized!.Date?.ToString(CaffoaDateOnlyConverter.DateFormat).Should().Be(data);
    }
    
    [Test]
    public void TestDateOnlyNonNullable()
    {
        var elem = new DateOnlyNullableTestObject()
        {
            Date = null
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
    
    [TestCase("1.2.22")]
    [TestCase("1. November")]
    [TestCase("WAAS")]
    public void TestDateOnlyNonNullable(string data)
    {
        var serialized = $"{{\"Date\": \"{data}\"}}";
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
    
    [Test]
    public void TestTimeOnlyRoundtrip()
    {
        var elem = new DateOnlyTestObject();
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        elem.Time.Should().Be(deserialized!.Time);
    }
    
    [TestCase("12:30:00")]
    [TestCase("17:00:00")]
    [TestCase(null)]
    public void TestTimeOnlyNullable(string? data)
    {
        var elem = new DateOnlyNullableTestObject()
        {
            Time = data == null ? null : TimeOnly.Parse(data)
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var deserialized = JsonConvert.DeserializeObject<DateOnlyNullableTestObject>(serialized);
        deserialized!.Time?.ToString(CaffoaTimeOnlyConverter.TimeFormat).Should().Be(data);
    }
    
    [TestCase("12:30", "12:30:00")]
    [TestCase("6:0", "06:00:00")]
    [TestCase("6:0:1", "06:00:01")]
    [TestCase("1:0:0", "01:00:00")]
    [TestCase("9:3", "09:03:00")]
    [TestCase("17:00:30", "17:00:30")]
    public void TestTimeOnlyValues(string data, string expected)
    {
        var deserialized = JsonConvert.DeserializeObject<DateOnlyNullableTestObject>($"{{\"Time\": \"{data}\"}}");
        deserialized!.Time?.ToString(CaffoaTimeOnlyConverter.TimeFormat).Should().Be(expected);
    }
    [TestCase("1.2.22")]
    [TestCase("1. November")]
    [TestCase("WAAS")]
    [TestCase("17 Uhr 30")]
    [TestCase("25:00")]
    public void TestTimeOnlyErrors(string data)
    {
        var serialized = $"{{\"Time\": \"{data}\"}}";
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
    [Test]
    public void TestTimeOnlyNonNullable()
    {
        var elem = new DateOnlyNullableTestObject()
        {
            Time = null
        };
        var serialized = JsonConvert.SerializeObject(elem);
        var act = () =>JsonConvert.DeserializeObject<DateOnlyTestObject>(serialized);
        act.Should().Throw<JsonSerializationException>();
    }
}