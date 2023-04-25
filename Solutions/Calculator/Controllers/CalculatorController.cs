using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public string InitialPage()
    {
        return "Bem vindo(a) a calculadora em C#";
    }

    [HttpGet("sum/{firstnumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstnumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok((ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("divide/{firstnumber}/{secondNumber}")]
    public IActionResult Divide(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok((ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("minus/{firstnumber}/{secondNumber}")]
    public IActionResult Minus(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok((ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("squareroot/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (verifyIsNumber(number))
        {
            return Ok(Math.Sqrt(ConvertToDouble(number)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("average/{firstnumber}/{secondnumber}")]
    public IActionResult Average(string firstNumber, string secondNumber)
    {
        if(verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok(((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2).ToString());
        }

        return BadRequest("Invalid Input");
    }

    public double ConvertToDouble(string number)
    {
        if(double.TryParse(number, out double result))
        {
            return result;
        }

        return 0;
    }

    public decimal ConvertToDecimal(string number)
    {
        if (decimal.TryParse(number, out var decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }

    public bool verifyIsNumber(string number)
    {
        return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double result);   
    }
}
