namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        ApplyFunction(numbers, n => n + 1);
                        break;
                    case "subtract":
                        ApplyFunction(numbers, n => n - 1);
                        break;
                    case "multiply":
                        ApplyFunction(numbers, n => n * 2);
                        break;
                    case "print":
                        ApplyAction(numbers, n => Console.Write(n + " "), Console.WriteLine);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                command = Console.ReadLine();
            }
        }

        public static void ApplyFunction(List<int> numbers, Func<int, int> func)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = func(numbers[i]);
            }
        }

        public static void ApplyAction(List<int> numbers, Action<int> action, Action<int> lastAct)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                action(numbers[i]);
            }

            lastAct(numbers[numbers.Count - 1]);
        }
    }
}
