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
            var result = operationType switch
            {
                OperationType.Add => this.operationService.Add(num1, num2),
                OperationType.Subtract => this.operationService.Subtract(num1, num2),
                OperationType.Division => this.operationService.Division(num1, num2),
                OperationType.Multiply => this.operationService.Multiply(num1, num2),
                _ => throw new ArgumentException("Wrong Operation Type Selected"),
            };

            return result;
        }
    }
}
