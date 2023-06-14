using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
   

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (isNumeric(firstNumber) && isNumeric(secondNumber)) 
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
            return BadRequest("Invalid Input");
    }


    private bool isNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out number
            );
        return isNumber;
    }

    private decimal ConvertToDecimal (string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;

    }
}
