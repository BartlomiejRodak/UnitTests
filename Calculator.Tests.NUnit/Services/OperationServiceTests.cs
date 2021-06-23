using System;
using AutoFixture;
using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Tests.NUnit.Services
{
    /// <summary>
    /// Unit tests without Mocks (Autofixture, FluentAssertions) NUnit
    /// </summary>
    
    [TestFixture]
    public sealed class OperationServiceTests
    {
        private IOperationService sut;

        [SetUp]
        public void SetUp()
        {
            sut = new OperationService();
        }

        #region Standard Assertion
        [Test]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Correct_Result_Example_With_Normal_Assertion()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Decimal_Result_Example_With_Normal_Assertion()
        {
            // Arrange
            // Act
            var result = sut.Add(1, 2);

            // Assert
            Assert.AreEqual(typeof(decimal), result.GetType());
        }

        [Test]
        public void Multiply_Given_Two_Numbers_When_Multiply_With_Zero_Then_Return_Zero()
        {
            // Arrange
            // Act
            var value1 = 1m;
            var value2 = 0m;
            var result = sut.Multiply(value1, value2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Multiply_Given_Two_Numbers_When_Multiply_With_Zero_Then_Return_Zero_Swapped()
        {
            // Arrange
            // Act
            var value1 = 0m;
            var value2 = 1m;
            var result = sut.Multiply(value1, value2);

            // Assert
            Assert.AreEqual(0, result);
        }
        #endregion

        #region Fluent Assertion Unit tests
        [Test]
        public void Add_Given_Two_Numbers_When_Add_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(1, 2);

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Zero_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(0, 2);

            // Assert
            result.Should().Be(2);
        }


        [Test]
        public void Add_Given_Two_Numbers_When_One_Number_Is_Not_Integer_Then_Return_Correct_Result()
        {
            // Arrange
            // Act
            var result = this.sut.Add(3, 2.5m);

            // Assert
            result.Should().Be(5.5m);
        }

        [Test]
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
        [Test]
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
        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 1, -1)]
        [TestCase(2.5, 3, 7.5)]
        [TestCase(0.1, 0.1, 0.01)]
        public void Multiply_Given_Two_Numbers_When_Multiply_Then_Return_Correct_Result(decimal num1, decimal num2, decimal expectedResult)
        {
            // Arrange
            // Act
            var result = this.sut.Multiply(num1, num2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestCase(3, 3, 1)]
        [TestCase(0, 3, 0)]
        [TestCase(7.5, 2.5, 3)]
        [TestCase(-3, 1, -3)]
        [TestCase(0.2, 0.1, 2)]
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
        [Test]
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
        [Test]
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

        [Test]
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
