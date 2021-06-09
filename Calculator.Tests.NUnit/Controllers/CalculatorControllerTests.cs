using AutoFixture;
using Calculator.API.Controllers;
using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Calculator.Tests.NUnit.Controllers
{
    /// <summary>
    /// Controller unit tests with Mock
    /// </summary>
    [TestFixture]
    public sealed class CalculatorControllerTests
    {
        private Mock<ICalculatorService> calculatorServiceMock;

        private CalculatorController sut;

        [SetUp]
        public void SetUp()
        {
            calculatorServiceMock = new Mock<ICalculatorService>();

            sut = new CalculatorController(calculatorServiceMock.Object);
        }

        [Test]
        public void GetOperation_Given_Values_When_GetOperation_Then_Return_Correct_Type()
        {
            // Arrange
            var fixture = new Fixture();
            var operationType = fixture.Create<OperationType>();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            var result = sut.GetOperation(operationType, num1, num2);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void GetOperation_Given_Values_When_GetOperation_Then_Call_It_Once()
        {
            // Arrange
            var fixture = new Fixture();
            var operationType = fixture.Create<OperationType>();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            sut.GetOperation(operationType, num1, num2);

            // Assert
            calculatorServiceMock.Verify(x => x.Calculate(operationType, num1, num2), Times.Once);
        }
    }
}
