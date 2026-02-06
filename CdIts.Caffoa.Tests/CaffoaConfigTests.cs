using AwesomeAssertions;
using CdIts.Caffoa.Cli.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdIts.Caffoa.Tests
{
    public class CaffoaConfigTests
    {
        [Test]
        public void SealClasses_ShouldReturnFalse_WhenUseInheritanceIsTrue()
        {
            var config = new CaffoaConfig
            {
                UseInheritance = true,
                GenerateEqualsMethods = true
            };

            config.SealClasses(null).Should().BeFalse();
        }

        [Test]
        public void SealClasses_ShouldReturnFalse_WhenSealClassesWithEqualsMethodsIsFalse()
        {
            var config = new CaffoaConfig
            {
                SealClassesWithEqualsMethods = false,
                GenerateEqualsMethods = true
            };
            config.SealClasses(null).Should().BeFalse();
        }

        [Test]
        public void SealClasses_ShouldReturnTrue_WhenGenerateEqualsMethodsIsTrue()
        {
            var config = new CaffoaConfig
            {
                GenerateEqualsMethods = true,
            };
            config.SealClasses(null).Should().BeTrue();
        }
    }
}
