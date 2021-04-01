using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Services
{
    public class OperationServiceTests
    {
        private readonly IOperationService sut;

        public OperationServiceTests()
        {
            this.sut = new OperationService();
        }

        #region Standard Assertion
        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Correct_Result_Example_With_Normal_Assertion()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Decimal_Result_Example_With_Normal_Assertion()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            Assert.Equal(typeof(decimal), result.GetType());
        }
        #endregion

        #region Fluent Assertion Unit tests
        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Zero_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = sut.Add(0, 2);

            // Assert
            result.Should().Be(2);
        }


        [Fact]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Not_Integer_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = sut.Add(3, 2.5m);

            // Assert
            result.Should().Be(5.5m);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Decimal_Result()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            result.Should().BeOfType(typeof(decimal));
        }
        #endregion

        #region Aggregated (Few assertions in one test)
        [Fact]
        public void Subtract_Given_Two_Numbers_When_Subtract_Then_Return_Correct_Decimal_Result()
        {
            // Arrange
            // Act
            var result = sut.Subtract(1, 2);

            // Assert
            result.Should().Be(-1);
            result.Should().BeOfType(typeof(decimal));
        }
        #endregion
    }
}
