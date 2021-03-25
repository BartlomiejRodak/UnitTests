using System;
using Calculator.API.Services.Abstraction;

namespace Calculator.API.Services
{
    public class OperationService: IOperationService
    {
        public decimal Add(decimal num1, decimal num2)
        {
            var result = num1 + num2;
            return result;
        }

        public decimal Subtract(decimal num1, decimal num2)
        {
            var result = num1 - num2;
            return result;
        }

        public decimal Division(decimal num1, decimal num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Cannot be divided by zero.");
            }
            var result = num1 / num2;
            return result;
        }

        public decimal Multiply(decimal num1, decimal num2)
        {
            var result = num1 * num2;
            return result;
        }
    }
}
