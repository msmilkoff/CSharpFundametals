namespace _07.BasicMath
{
    using System;
    using System.Reflection;

    public class BasicMathMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParams = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string operation = inputParams[0];
                double firstNumber = double.Parse(inputParams[1]);
                double secondNumber = double.Parse(inputParams[2]);

                var type = typeof(MathUtil);
                var methodInfo = type.GetMethod(operation, BindingFlags.Static | BindingFlags.Public);
                var result = methodInfo.Invoke(null, new object[] {firstNumber, secondNumber});

                Console.WriteLine($"{result:F2}");

                input = Console.ReadLine();
            }
        }
    }

    public static class MathUtil
    {
        public static double Sum(double firstNumber, double secondNumber)
        {
            double result = firstNumber + secondNumber;
            return result;
        }

        public static double Subtract(double firstNumber, double secondNumber)
        {
            double result = firstNumber - secondNumber;
            return result;
        }

        public static double Multiply(double firstNumber, double secondNumber)
        {
            double result = firstNumber * secondNumber;
            return result;
        }

        public static double Divide(double firstNumber, double secondNumber)
        {
            double result = firstNumber / secondNumber;
            return result;
        }

        public static double Percentage(double firstNumber, double secondNumber)
        {
            double result = firstNumber * (secondNumber / 100);
            return result;
        }
    }
}
