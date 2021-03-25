using System;
using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;

namespace Calculator.API.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IOperationService operationService;

        public CalculatorService(IOperationService operationService)
        {
            this.operationService = operationService;
        }

        public decimal Calculate(OperationType operationType, decimal num1, decimal num2)
        {
            decimal result;
            switch (operationType)
            {
                case OperationType.Add:
                    result = this.operationService.Add(num1, num2);
                    break;
                case OperationType.Subtract:
                    result = this.operationService.Subtract(num1, num2);
                    break;
                case OperationType.Division:
                    result = this.operationService.Division(num1, num2);
                    break;
                case OperationType.Multiply:
                    result = this.operationService.Multiply(num1, num2);
                    break;
                default:
                    throw new ArgumentException("Wrong Operation Type Selected");
            }

            return result;
        }
    }
}
