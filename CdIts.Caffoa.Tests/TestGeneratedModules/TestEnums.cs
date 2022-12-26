using System;
using DemoV2.Model;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests.TestGeneratedModules;

public class TestEnums
{
    [Test]
    public void TestIntegerEnumsCorrectValue()
    {
        var user = new JObject();
        user["type"] = "simple";
        user["name"] = "Caffoa";
        user["ageGroup"] = 18;
        var parsed = JsonConvert.DeserializeObject<User>(user.ToString());
        parsed!.AgeGroup.Should().Be(User.AgeGroupValue._18);
    }

    [Test]
    public void TestIntegerEnumsForbiddenValue()
    {
        var user = new JObject();
        user["type"] = "simple";
        user["name"] = "Caffoa";
        user["ageGroup"] = 20;
        Action action = () => JsonConvert.DeserializeObject<User>(user.ToString());
        action.Should().Throw<ArgumentException>().WithMessage("Could not*20*");
    }

    [Test]
    public void TestStringEnumsForbiddenValue()
    {
        var user = new JObject();
        user["type"] = "simple";
        user["name"] = "Caffoa";
        user["role"] = "Supervisor";
        Action action = () => JsonConvert.DeserializeObject<User>(user.ToString());
        action.Should().Throw<JsonSerializationException>().WithMessage("Error converting*");
    }

    [TestCase("admin")]
    [TestCase("Admin")]
    [TestCase("ADMIN")]
    [TestCase(" admin ")]
    [TestCase(" Admin ")]
    public void TestStringEnumsRegularValue(string role)
    {
        var user = new JObject();
        user["type"] = "simple";
        user["name"] = "Caffoa";
        user["role"] = role;
        var userObject = JsonConvert.DeserializeObject<User>(user.ToString());
        userObject!.Role.Should().Be(User.RoleValue.Admin);
    }
}