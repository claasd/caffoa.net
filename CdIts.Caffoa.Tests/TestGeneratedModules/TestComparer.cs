using DemoV2.Model;
using DemoV2.Model.Base;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace CdIts.Caffoa.Tests.TestGeneratedModules;

public class TestComparer
{
    [Test]
    public void EqualsDoesNotThrowErrorOnNullSequence()
    {
        var user = new User()
        {
            Emails = new[] { "some@email.de" }
        };
        var user2 = new User(user)
        {
            Emails = null
        };
        user.Equals(user2).Should().Be(false);
        user2.Equals(user).Should().Be(false);
    }
}