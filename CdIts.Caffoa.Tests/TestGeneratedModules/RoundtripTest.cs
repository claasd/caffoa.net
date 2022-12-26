using System.Collections.Generic;
using System.Threading.Tasks;
using CdIts.AzFuncTestHelper;
using DemoV2.Services;
using DemoV2;
using DemoV2.Model;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests.TestGeneratedModules;

public class RoundtripTest
{
    [Test]
    public async Task RoundtripGeneratedClasses()
    {
        var user = new User()
        {
            Name = "Claas"
        };
        var functions = new DemoV2UserFunctions(NullLogger<DemoV2UserFunctions>.Instance, new UserServiceFactory());
        await functions.UserPostAsync(new RequestBuilder().Content(user).Build()).Check();
        var users = await functions.UsersGetAsync(RequestBuilder.Default).Json<List<User>>();
        users.Should().HaveCount(1);
        users[0].Name.Should().Be("Claas");
    }
}