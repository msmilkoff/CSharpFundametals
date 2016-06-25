namespace _05.FibonacciNumbers
{
    using System.Collections.Generic;
    using System;
    using System.Numerics;

    public class FibonacciNumbers
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            var fib = new Fibonacci();
            var sequence = fib.GetNumbersInRange(start, end);

            Console.WriteLine(string.Join(", ", sequence));
        }
    }

    public class Fibonacci
    {
        public Fibonacci()
        {
        }

        public List<BigInteger>Numbers{ get; set; }

        public List<BigInteger> GetNumbersInRange(int startPosition, int endPosition)
        {
            var result = new List<BigInteger>();
            for (int i = startPosition; i < endPosition; i++)
            {
                result.Add(GetNthFibonacciNumber(i));
            }

            return result;
        }

        private BigInteger GetNthFibonacciNumber(int n)
        {
            BigInteger a = 0;
            BigInteger b = 1;
            for (int i = 0; i < n; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}
