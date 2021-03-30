using Calculator.API.Services;
using Calculator.API.Services.Abstraction;
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
    }
}
