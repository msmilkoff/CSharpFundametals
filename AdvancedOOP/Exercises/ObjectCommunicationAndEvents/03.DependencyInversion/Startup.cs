namespace _03.DependencyInversion
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            IStrategy strategy = null;
            var calculator = new PrimitiveCalculator();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                if (tokens[0] == "mode")
                {
                    char @operator = char.Parse(tokens[1]);
                    strategy = GetStrategy(@operator);
                    calculator.ChangeStrategy(strategy);

                    input = Console.ReadLine();
                    continue;
                }

                int result = calculator.PerformCalculation(int.Parse(tokens[0]), int.Parse(tokens[1]));
                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }

        private static IStrategy GetStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return new AdditionStrategy();
                case '-':
                    return new SubtractionStrategy();
                case '*':
                    return new MultiplicationStrategy();
                case '/':
                    return new DivisionStrategy();
                default:
                    throw new NotSupportedException($"Operator '{@operator}' is not supported");
            }
        }
    }
}
