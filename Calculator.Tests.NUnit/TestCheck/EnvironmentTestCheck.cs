using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Tests.NUnit.TestCheck
{
    /// <summary>
    /// Environment configuration check
    /// </summary>
    public sealed class EnvironmentCheckTests
    {
        [Test]
        public void EnvironmentTestCheckPositive()
        {
            true.Should().BeTrue();
        }
    }
}
