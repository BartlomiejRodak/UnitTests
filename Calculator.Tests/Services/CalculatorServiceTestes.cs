using AutoFixture;
using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;
using FluentAssertions;
using Moq;
using Xunit;

namespace Calculator.Tests.Services
{
    public class CalculatorServiceTestes
    {
        private readonly Mock<IOperationService> operationServiceMock;

        private readonly ICalculatorService sut;

        public CalculatorServiceTestes()
        {
            this.operationServiceMock = new Mock<IOperationService>();
            this.sut = new CalculatorService(this.operationServiceMock.Object);
        }

        #region Simple mock
        [Fact]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Add_Then_Return_Correct_Result()
        {
            // Arrange
            this.operationServiceMock
                .Setup(x => x.Add(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);

            // Act
            var result = this.sut.Calculate(OperationType.Add, 2m, 2m);

            // Assert
            result.Should().Be(4);
        }
        #endregion

        #region Verify Any
        [Fact]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Subtract_Then_Subtract_Operation_Was_Called_Once()
        {
            // Arrange
            this.operationServiceMock
                .Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);

            // Act
            this.sut.Calculate(OperationType.Subtract, 2, 2);

            // Assert
            this.operationServiceMock.Verify(v => v.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
            this.operationServiceMock.Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }
        #endregion

        #region Verify
        [Fact]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Multiply_Then_Multiply_Operation_With_Correct_Numbers_Was_Called_Once()
        {
            // Arrange
            this.operationServiceMock
                .Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);
            var num1 = 2m;
            var num2 = 2m;

            // Act
            this.sut.Calculate(OperationType.Multiply, num1, num2);

            // Assert
            this.operationServiceMock
                .Verify(v => v.Multiply(It.Is<decimal>(x => x == num1), It.Is<decimal>(x => x == num2)), Times.Once);
        }
        #endregion

        #region Verify + AutoFixture
        [Fact]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Division_Then_Division_Operation_With_Correct_Numbers_Was_Called_Once()
        {
            // Arrange
            this.operationServiceMock
                .Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);
            var fixture = new Fixture();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            this.sut.Calculate(OperationType.Subtract, num1, num2);

            // Assert
            this.operationServiceMock
                .Verify(v => v.Subtract(It.Is<decimal>(x => x == num1), It.Is<decimal>(x => x == num2)), Times.Once);
            this.operationServiceMock
                .Verify(v => v.Add(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            this.operationServiceMock
                .Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            this.operationServiceMock
                .Verify(v => v.Division(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }

        [Fact]
        public void Calculate_Given_Calculation_Type_And_Numbers_When_Division_Then_Division_Operation_With_Correct_Numbers_Was_Called_Once_Direct()
        {
            // Arrange
            this.operationServiceMock
                .Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(4);
            var fixture = new Fixture();
            var num1 = fixture.Create<decimal>();
            var num2 = fixture.Create<decimal>();

            // Act
            this.sut.Calculate(OperationType.Subtract, num1, num2);

            // Assert
            this.operationServiceMock
                .Verify(v => v.Subtract(num1, num2), Times.Once);
            this.operationServiceMock
                .Verify(v => v.Add(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            this.operationServiceMock
                .Verify(v => v.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            this.operationServiceMock
                .Verify(v => v.Division(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
        }
        #endregion
    }
}
