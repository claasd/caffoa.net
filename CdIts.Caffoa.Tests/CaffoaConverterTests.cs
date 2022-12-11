using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caffoa;
using Caffoa.Defaults;
using Caffoa.Extensions;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using EnumConverter = Caffoa.EnumConverter;

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
    public void TestConvertTimeOnly()
    {
        var input = "7:3";
        var date = _converter.ParseTimeOnly(input, "name");
        date.ToString("HH:mm:ss").Should().Be("07:03:00");
    }

    [Test]
    public void TestConvertTimeSpan()
    {
        var input = "7:3";
        var date = _converter.ParseTimeSpan(input, "name");
        date.ToString().Should().Be("07:03:00");
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

    [TestCase("true", true)]
    [TestCase("True", true)]
    [TestCase("TRUE", true)]
    [TestCase("false", false)]
    [TestCase("False", false)]
    [TestCase("FALSE", false)]
    public void TestConvertBool(string input, bool result)
    {
        _converter.Parse<bool>(input, "name").Should().Be(result);
    }

    public enum TestEnumType
    {
        [EnumMember(Value = "enum1")] Enum1,
        Enum2,
        [EnumMember(Value = "enum space")] EnumSpace,

        [EnumMember(Value = "enum-special_CHARS")]
        EnumSpecialChars
    }

    [TestCase("enum1", TestEnumType.Enum1)]
    [TestCase("ENUM1", TestEnumType.Enum1)]
    [TestCase("Enum1", TestEnumType.Enum1)]
    [TestCase("Enum2", TestEnumType.Enum2)]
    [TestCase("enum2", TestEnumType.Enum2)]
    [TestCase("EnumSpace", TestEnumType.EnumSpace)]
    [TestCase("enum space", TestEnumType.EnumSpace)]
    [TestCase("ENUM SPACE", TestEnumType.EnumSpace)]
    [TestCase("EnumSpecialChars", TestEnumType.EnumSpecialChars)]
    [TestCase("enum-special_chars", TestEnumType.EnumSpecialChars)]
    public void EnumConverterTests(string input, TestEnumType result)
    {
        _converter.ParseEnum<TestEnumType>(input, "name").Should().Be(result);
    }

    [TestCase("enum12")]
    [TestCase("enum5")]
    [TestCase("enum-space")]
    public void EnumNegativeTests(string input)
    {
        _converter.Invoking(c => c.ParseEnum<TestEnumType>(input, "PARAM")).Should().Throw<DefaultCaffoaClientError>()
            .WithMessage($"Error*PARAM*TestEnumType*{input}*is*invalid*");
    }

    [TestCase(TestEnumType.Enum1, "enum1")]
    [TestCase(TestEnumType.Enum2, "Enum2")]
    [TestCase(TestEnumType.EnumSpace, "enum space")]
    [TestCase(TestEnumType.EnumSpecialChars, "enum-special_CHARS")]
    [TestCase((TestEnumType)99, "99")]
    public void EnumToString(TestEnumType input, string result)
    {
        input.Value().Should().Be(result);
    }

    [TestCase("enum1", TestEnumType.Enum1)]
    [TestCase("ENUM1", TestEnumType.Enum1)]
    [TestCase("Enum1", TestEnumType.Enum1)]
    [TestCase("Enum2", TestEnumType.Enum2)]
    [TestCase("enum2", TestEnumType.Enum2)]
    [TestCase("EnumSpace", TestEnumType.EnumSpace)]
    [TestCase("enum space", TestEnumType.EnumSpace)]
    [TestCase("ENUM SPACE", TestEnumType.EnumSpace)]
    [TestCase("EnumSpecialChars", TestEnumType.EnumSpecialChars)]
    [TestCase("enum-special_chars", TestEnumType.EnumSpecialChars)]
    public void EnumFromStringTests(string input, TestEnumType result)
    {
        EnumConverter.FromString<TestEnumType>(input).Should().Be(result);
    }
    
    [TestCase("enum12")]
    [TestCase("enum5")]
    [TestCase("enum-space")]
    public void EnumFromStringErrorTests(string input)
    {
        var act = ()=> EnumConverter.FromString<TestEnumType>(input);
        act.Should().Throw<InvalidEnumArgumentException>();
    }
}