namespace Calculator.Model
{
    public class Calcu
    {
        public double Sum(string firstNumber, string secondNumber) {
            return ConvertToDouble(firstNumber) + ConvertToDouble(secondNumber);
        }

        public double Subtraction(string firstNumber, string secondNumber) {
            return ConvertToDouble(firstNumber) - ConvertToDouble(secondNumber);
        }

        public double Multiplication(string firstNumber, string secondNumber)
        {
            return ConvertToDouble(firstNumber) * ConvertToDouble(secondNumber);
        }

        public double Division(string firstNumber, string secondNumber)
        {
            return ConvertToDouble(firstNumber) / ConvertToDouble(secondNumber);
        }

        public double SquareRoot(string firstNumber)
        {
            return Math.Sqrt(ConvertToDouble(firstNumber));
        }

        public double Average(string firstNumber, string secondNumber)
        {
            return Sum(firstNumber, secondNumber) / 2;
        }

        public double ConvertToDouble(string number)
        {
            if (double.TryParse(number, out double result))
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
    }
}
