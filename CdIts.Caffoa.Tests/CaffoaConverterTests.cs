using System;
using Caffoa;
using Caffoa.Defaults;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class CaffoaConverterTests
{
    private ICaffoaConverter _converter = null!;

    [SetUp]
    public void Setup()
    {
        _converter = new DefaultCaffoaConverter(new DefaultCaffoaErrorHandler(NullLogger.Instance));
    }
    
    [Test]
    public void TestConvertGuid()
    {
        var guid = Guid.NewGuid();
        _converter.ParseGuid(guid.ToString(), "name").Should().Be(guid);
    }
    
    [Test]
    public void TestConvertDateOnly()
    {
        var input = "2022-02-12";
        var date = _converter.ParseDate(input, "name");
        date.ToString("s").Should().Be("2022-02-12T00:00:00");
    }
    
    [Test]
    public void TestConvertDateTime()
    {
        var input = "2022-02-12T12:30:11";
        var date = _converter.ParseDateTime(input, "name");
        date.ToString("s").Should().Be("2022-02-12T12:30:11");
    }
    
    [Test]
    public void TestConvertInt()
    {
        _converter.Parse<int>("9522", "name").Should().Be(9522);
    }
    
    [Test]
    public void TestConvertDouble()
    {
        _converter.Parse<double>("9522.1223", "name").Should().Be(9522.1223);
    }
    
    [Test]
    public void TestConvertULong()
    {
        _converter.Parse<ulong>("9223372036854775809", "name").Should().Be(9223372036854775809);
    }
    
    [Test]
    public void TestConvertBool()
    {
        _converter.Parse<bool>("true", "name").Should().Be(true);
        _converter.Parse<bool>("True", "name").Should().Be(true);
        _converter.Parse<bool>("TRUE", "name").Should().Be(true);
        _converter.Parse<bool>("false", "name").Should().Be(false);
        _converter.Parse<bool>("False", "name").Should().Be(false);
        _converter.Parse<bool>("FALSE", "name").Should().Be(false);
    }
}