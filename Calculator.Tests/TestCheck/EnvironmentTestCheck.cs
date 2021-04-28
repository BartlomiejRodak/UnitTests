using FluentAssertions;
using Xunit;

namespace Calculator.Tests.TestCheck
{
    /// <summary>
    /// Environment configuration check
    /// </summary>
    public sealed class EnvironmentCheckTests
    {
        [Fact]
        public void EnvironmentTestCheckPositive()
        {
            true.Should().BeTrue();
        }
    }
}
