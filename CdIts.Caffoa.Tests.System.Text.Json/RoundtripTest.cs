using AwesomeAssertions;
using CdIts.AzFuncTestHelper;
using DemoV2.Text.Json;
using DemoV2.Text.Json.Model;
using DemoV2.Text.Json.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace CdIts.Caffoa.Tests.System.Text.Json;

public class RoundtripTest
{
    [OneTimeSetUp]
    public void Prepare()
    {
        Settings.DefaultJsonFlavor = Settings.JsonFlavor.SystemTextJson;
    }
    [Test]
    public async Task RoundtripGeneratedClasses()
    {
        var user = new STJUser()
        {
            Name = "Claas"
        };
        var functions = new DemoV2TextJsonUserFunctions(NullLogger<DemoV2TextJsonUserFunctions>.Instance, new UserServiceFactory());
        await functions.UserPostAsync(new RequestBuilder().Content(user).Build()).Check();
        var users = await functions.UsersGetAsync(RequestBuilder.Default).Json<List<STJUser>>();
        users.Should().HaveCount(1);
        users[0].Name.Should().Be("Claas");
    }
}