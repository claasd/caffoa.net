using AwesomeAssertions;
using DemoV2.Model;
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
    [Test]
    public void EqualsShouldConsiderNullSequencesEqual()
    {
        var user = new User()
        {
            Emails = null
        };
        var user2 = new User(user)
        {
            Emails = null
        };
        user.Equals(user2).Should().Be(true);
        user2.Equals(user).Should().Be(true);
    }
}