using FluentAssertions;
using Xunit;

namespace Calculator.Tests.TestCheck
{
    public sealed class EnvironmentCheckTests
    {
        [Fact]
        public void EnvironmentTestCheckPositive()
        {
            true.Should().BeTrue();
        }

        [Fact]
        public void EnvironmentTestCheckNegative()
        {
            true.Should().BeFalse();
        }
    }
}
