using CalculatorApi.Models.Enums;

namespace Calculator.API.Services.Abstraction
{
    public interface ICalculatorService
    {
        decimal Calculate(OperationType operationType, decimal num1, decimal num2);
    }
}
