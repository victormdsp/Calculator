using Calculator.Model;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;
    private Calcu calculator = new Calcu();

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
            return Ok(calculator.Sum(firstNumber, secondNumber).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstnumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok(calculator.Multiplication(firstNumber, secondNumber).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("divide/{firstnumber}/{secondNumber}")]
    public IActionResult Divide(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok(calculator.Division(firstNumber, secondNumber).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("minus/{firstnumber}/{secondNumber}")]
    public IActionResult Minus(string firstNumber, string secondNumber)
    {
        if (verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok(calculator.Subtraction((firstNumber), (secondNumber)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("squareroot/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (verifyIsNumber(number))
        {
            return Ok(calculator.SquareRoot((number)).ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("average/{firstnumber}/{secondnumber}")]
    public IActionResult Average(string firstNumber, string secondNumber)
    {
        if(verifyIsNumber(firstNumber) && verifyIsNumber(secondNumber))
        {
            return Ok(calculator.Average(firstNumber ,secondNumber).ToString());
        }

        return BadRequest("Invalid Input");
    }

    public bool verifyIsNumber(string number)
    {
        return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double result);
    }
}
