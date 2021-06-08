using System;
using AutoFixture;
using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;
using FluentAssertions;
using Moq;
using NUnit;
using NUnit.Framework;

namespace Calculator.Tests.NUnit.Services
{
    /// <summary>
    /// Unit tests with Mocks
    /// </summary>

    [TestFixture]
    public class CalculatorServiceTestes
    {
        private Mock<IOperationService> operationServiceMock;

        private ICalculatorService sut;

        [SetUp]
        public void SetUp()
        {
            operationServiceMock = new Mock<IOperationService>();
            sut = new CalculatorService(operationServiceMock.Object);
        }

        #region Simple mock
        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Add_Then_Return_Correct_Result()
        {
            // Arrange
            operationServiceMock
                .Setup(x => x.Add(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);

            // Act
            var result = sut.Calculate(OperationType.Add, 2m, 2m);

            // Assert
            result.Should().Be(4);
        }
        #endregion

        #region Verify Any
        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Subtract_Then_Subtract_Operation_Was_Called_Once()
        {
            // Arrange
            operationServiceMock
                .Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);

            // Act
            sut.Calculate(OperationType.Subtract, 2, 2);

            // Assert
            operationServiceMock.Verify(v => v.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
            operationServiceMock.Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }
        #endregion

        #region Verify
        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Multiply_Then_Multiply_Operation_With_Correct_Numbers_Was_Called_Once()
        {
            // Arrange
            operationServiceMock
                .Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);
            var num1 = 2m;
            var num2 = 2m;

            // Act
            sut.Calculate(OperationType.Multiply, num1, num2);

            // Assert
            operationServiceMock
                .Verify(v => v.Multiply(It.Is<decimal>(x => x == num1), It.Is<decimal>(x => x == num2)), Times.Once);
        }
        #endregion

        #region Verify + AutoFixture
        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Multiply_Then_Division_Operation_With_Correct_Numbers_Was_Called_Once()
        {
            // Arrange
            var fixture = new Fixture();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            sut.Calculate(OperationType.Subtract, num1, num2);

            // Assert
            operationServiceMock
                .Verify(v => v.Subtract(It.Is<decimal>(x => x == num1), It.Is<decimal>(x => x == num2)), Times.Once);
            operationServiceMock
                .Verify(v => v.Add(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            operationServiceMock
                .Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            operationServiceMock
                .Verify(v => v.Division(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }

        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Division_Then_Division_Operation_With_Correct_Numbers_Was_Called_Once_Direct()
        {
            // Arrange
            var fixture = new Fixture();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            sut.Calculate(OperationType.Division, num1, num2);

            // Assert
            operationServiceMock
                .Verify(v => v.Division(num1, num2), Times.Once);
            operationServiceMock
                .Verify(v => v.Add(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            operationServiceMock
                .Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            operationServiceMock
                .Verify(v => v.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }
        #endregion

        #region Test with Exception
        [Test]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Wrong_Type_Then_Throw_Exception()
        {
            // Arrange
            // Act
            // Assert
            sut.Invoking(x => x
            .Calculate(OperationType.Undefined, It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Should().Throw<ArgumentException>()
                .WithMessage("Wrong Operation Type Selected");
        }
        #endregion
    }
}
