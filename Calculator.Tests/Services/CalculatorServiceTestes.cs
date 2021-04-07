﻿using Calculator.API.Services;
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
    }
}
