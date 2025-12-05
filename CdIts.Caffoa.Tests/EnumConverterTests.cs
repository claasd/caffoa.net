using AwesomeAssertions;
using CdIts.Caffoa.Tests.TestClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests;

public class EnumConverterTests
{
    [Test]
    public void EnumConverterRoundtripTest()
    {
        var data = new EnumClassTestObject()
        {
            Data2 = TestEnum1.Value3
        };
        var json = JsonConvert.SerializeObject(data);
        var token = JToken.Parse(json);
        token["Data1"].ToString().Should().Be("Value1");
        token["Data2"].ToString().Should().Be("Value3");
        var data2 = JsonConvert.DeserializeObject<EnumClassTestObject>(json);
        data2.Data1.Value.Should().Be(data.Data1.Value);
        data2.Data2.Value.Should().Be(data.Data2.Value);
    }
    
    [Test]
    public void EnumConverterRoundtripWithNullTest()
    {
        var data = new EnumClassTestObject();
        var json = JsonConvert.SerializeObject(data);
        var token = JToken.Parse(json);
        token["Data1"].ToString().Should().Be("Value1");
        token["Data2"].Type.Should().Be(JTokenType.Null);
        var data2 = JsonConvert.DeserializeObject<EnumClassTestObject>(json);
        data2.Data1.Value.Should().Be(data.Data1.Value);
        data2.Data2.Should().BeNull();
    }

    [Test]
    public void TestSerializationWithOneMember()
    {
        var json2 = """{"Data1":"Value2"}""";
        var data = JsonConvert.DeserializeObject<EnumClassTestObject>(json2);
        data.Data1.Value.Should().Be(TestEnum1.Value2);
        data.Data2.Should().BeNull();
    }
    
    [Test]
    public void TestSerializationWithOnlySecondMemberMember()
    {
        var json2 = """{"Data2":"Value2"}""";
        var data = JsonConvert.DeserializeObject<EnumClassTestObject>(json2);
        data.Data1.Value.Should().Be(TestEnum1.Value1);
        data.Data2.Should().Be(TestEnum1.Value2);
    }
}