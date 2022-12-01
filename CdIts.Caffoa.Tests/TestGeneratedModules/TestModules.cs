using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoV3;
using DemoV3.Model;
using DemoV3.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests.TestGeneratedModules;

public class TestModules
{
    [Test]
    public async Task UserRoundtrip()
    {

        var func = new DemoV3UserFunctions(NullLogger<DemoV3UserFunctions>.Instance, new UserServiceFactory());
        var user = new UserWithId()
        {
            Name = "Caffoa",
            Birthdate = new DateOnly(1980, 1, 1)
        };
        var userList = await func.UserPostAsync(new RequestBuilder().Content(user).Build()).Json<List<UserWithId>>();
        userList.Should().HaveCount(1);
        user = userList[0];
        user.PreferredContactTime.Should().Be(new TimeOnly(12, 0, 0));
        user.Birthdate.Should().Be(new DateOnly(1980, 1, 1));
        user.PreferredContactTime = null;
        user.Birthdate = null;
        user = await func.UserPutAsync(new RequestBuilder().Content(user).Build(), user.Id).Json<UserWithId>();
        user.PreferredContactTime.Should().BeNull();
        user.Birthdate.Should().BeNull();
    }
}