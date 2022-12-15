using System.Collections.Generic;
using System.Threading.Tasks;
using CdIts.AzFuncTestHelper;
using DemoV3;
using DemoV3.Model;
using DemoV3.Services;
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
        var functions = new DemoV3UserFunctions(NullLogger<DemoV3UserFunctions>.Instance, new UserServiceFactory());
        await functions.UserPostAsync(new RequestBuilder().Content(user).Build()).Check();
        var users = await functions.UsersGetAsync(RequestBuilder.Default).Json<List<User>>();
        users.Should().HaveCount(1);
        users[0].Name.Should().Be("Claas");
    }
}