using Calculator.API.Services.Abstraction;
using CalculatorApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult GetOperation(OperationType operationType, decimal num1, decimal num2)
        {
            var result = this.calculatorService.Calculate(operationType, num1, num2);
            return Ok(result);
        }
    }
}
