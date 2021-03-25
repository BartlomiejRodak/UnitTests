namespace Calculator.API.Services.Abstraction
{
    public interface IOperationService
    {
        decimal Add(decimal num1, decimal num2);
        decimal Subtract(decimal num1, decimal num2);
        decimal Division(decimal num1, decimal num2);
        decimal Multiply(decimal num1, decimal num2);
    }
}
