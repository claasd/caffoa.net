using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
using CdIts.AzFuncTestHelper;
using DemoV2;
using DemoV2.Model;
using DemoV2.Services;
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

    [Test]
    public async Task TestOneOfWithGestUser()
    {
        GroupedOneOf data = new()
        {
            Element = new GuestUser()
            {
                Email = "guest@email.de",
            }
        };
        var functions = new DemoV2UserFunctions(NullLogger<DemoV2UserFunctions>.Instance, new UserServiceFactory());
        var result = await functions.EchoOneOfAsync(new RequestBuilder().Content(data).Build()).Json<GroupedOneOf>();
        result.Element.Should().BeOfType<GuestUser>();
    }
    
    [Test]
    public async Task TestOneOfWithUser()
    {
        GroupedOneOf data = new()
        {
            Element = new User()
            {
                Name = "Test"
            }
        };
        var functions = new DemoV2UserFunctions(NullLogger<DemoV2UserFunctions>.Instance, new UserServiceFactory());
        var result = await functions.EchoOneOfAsync(new RequestBuilder().Content(data).Build()).Json<GroupedOneOf>();
        result.Element.Should().BeOfType<User>();
    }
    
    
    [Test]
    public async Task TestOneOfArray()
    {
        var data = new List<AnyUser>();
        data.Add(new GuestUser()
        {
            Email = "guest@email.de",
        });
        data.Add(new User()
        {
            Name = "TestUser"
        });
        var functions = new DemoV2UserFunctions(NullLogger<DemoV2UserFunctions>.Instance, new UserServiceFactory());
        var result = await functions.EchoOneOfArrayAsync(new RequestBuilder().Content(data).Build()).Json<List<AnyUser>>();
        result.Should().HaveCount(2);
        result[0].Should().BeOfType<GuestUser>();
        result[1].Should().BeOfType<User>();
    }
}