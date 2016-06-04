namespace _04.BaseTenToAnyBase
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class BaseTenToAnyBase
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            int @base = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            string toNBase = ConvertToBaseN(number, @base);
            Console.WriteLine(toNBase);
        }

        public static string ConvertToBaseN(BigInteger number, int @base)
        {
            var stack = new Stack<string>();
            while (number >= @base)
            {
                stack.Push((number % @base).ToString());
                number /= @base;
            }

            string result = "" + number;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}
