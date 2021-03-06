using AutoFixture;
using Calculator.API.Controllers;
using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Calculator.Tests.Controllers
{
    /// <summary>
    /// Controller unit tests with Mock
    /// </summary>
    public sealed class CalculatorControllerTests
    {
        private readonly Mock<ICalculatorService> calculatorServiceMock;

        private readonly CalculatorController sut;

        public CalculatorControllerTests()
        {
            this.calculatorServiceMock = new Mock<ICalculatorService>();

            this.sut = new CalculatorController(this.calculatorServiceMock.Object);
        }

        [Fact]
        public void GetOperation_Given_Values_When_GetOperation_Then_Return_Correct_Type()
        {
            // Arrange
            var fixture = new Fixture();
            var operationType = fixture.Create<OperationType>();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            var result = this.sut.GetOperation(operationType, num1, num2);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetOperation_Given_Values_When_GetOperation_Then_Call_It_Once()
        {
            // Arrange
            var fixture = new Fixture();
            var operationType = fixture.Create<OperationType>();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            this.sut.GetOperation(operationType, num1, num2);

            // Assert
            this.calculatorServiceMock.Verify(x => x.Calculate(operationType, num1, num2), Times.Once);
        }
    }
}
