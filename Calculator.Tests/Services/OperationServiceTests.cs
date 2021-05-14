using System;
using AutoFixture;
using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Services
{
    /// <summary>
    /// Unit tests without Mocks (Autofixture, FluentAssertions)
    /// </summary>
    public sealed class OperationServiceTests
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
            var result = this.sut.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Decimal_Result_Example_With_Normal_Assertion()
        {
            // Arrange
            // Act
            var result = this.sut.Add(1, 2);

            // Assert
            Assert.Equal(typeof(decimal), result.GetType());
        }

        [Fact]
        public void Multiply_Given_Two_Numbers_When_Multiply_With_Zero_Then_Return_Zero()
        {
            // Arrange
            // Act
            var value1 = 1m;
            var value2 = 0m;
            var result = this.sut.Multiply(value1, value2);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Multiply_Given_Two_Numbers_When_Multiply_With_Zero_Then_Return_Zero_Swapped()
        {
            // Arrange
            // Act
            var value1 = 0m;
            var value2 = 1m;
            var result = this.sut.Multiply(value1, value2);

            // Assert
            Assert.Equal(0, result);
        }
        #endregion

        #region Fluent Assertion Unit tests
        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(1, 2);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Zero_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(0, 2);

            // Assert
            result.Should().Be(2);
        }


        [Fact]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Not_Integer_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(3, 2.5m);

            // Assert
            result.Should().Be(5.5m);
        }

        [Fact]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Decimal_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(1, 2);

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
            var result = this.sut.Subtract(1, 2);

            // Assert
            result.Should().Be(-1);
            result.Should().BeOfType(typeof(decimal));
        }
        #endregion

        #region TestCase
        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, -1)]
        [InlineData(2.5, 3, 7.5)]
        [InlineData(0.1, 0.1, 0.01)]
        public void Multiply_Given_Two_Numbers_When_Multiply_Then_Return_Correct_Result(decimal num1, decimal num2, decimal expectedResult)
        {
            // Arrange
            // Act
            var result = this.sut.Multiply(num1, num2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(3, 3, 1)]
        [InlineData(0, 3, 0)]
        [InlineData(7.5, 2.5, 3)]
        [InlineData(-3, 1, -3)]
        [InlineData(0.2, 0.1, 2)]
        public void Division_Given_Two_Numbers_When_Division_Then_Return_Correct_Result(decimal num1, decimal num2, decimal expectedResult)
        {
            // Arrange
            // Act
            var result = this.sut.Division(num1, num2);

            // Assert
            result.Should().Be(expectedResult);
        }
        #endregion

        #region Exception
        [Fact]
        public void Division_Given_Two_Numbers_When_Division_By_Zero_Then_Throw_Exception()
        {
            // Arrange
            // Act
            // Assert
            this.sut.Invoking(y => y.Division(3123, 0))
                .Should().Throw<ArgumentException>()
                .WithMessage("Cannot be divided by zero.");
        }
        #endregion

        #region AutoFixture
        [Fact]
        public void Division_Given_Two_Numbers_When_Division_By_Zero_Then_Throw_Exception_Using_Autofixture()
        {
            // Arrange
            var fixture = new Fixture();
            var randomFirstNumber = fixture.Create<decimal>();
            // Act
            // Assert
            this.sut.Invoking(y => y.Division(randomFirstNumber, 0))
                .Should().Throw<ArgumentException>()
                .WithMessage("Cannot be divided by zero.");
        }

        [Fact]
        public void Multiply_Given_Two_Numbers_When_Multiply_By_Zero_Then_Return_Zero()
        {
            // Arrange
            var fixture = new Fixture();
            var randomFirstNumber = fixture.Create<decimal>();

            // Act
            var result = this.sut.Multiply(randomFirstNumber, 0);

            // Assert
            result.Should().Be(0);
        }
        #endregion
    }
}
