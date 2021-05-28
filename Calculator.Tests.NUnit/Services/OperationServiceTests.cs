using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Tests.NUnit.Services
{
    /// <summary>
    /// Unit tests without Mocks (Autofixture, FluentAssertions)
    /// </summary>
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
    }
}
