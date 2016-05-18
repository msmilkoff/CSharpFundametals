namespace _08.RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return GetFibonacci(n - 2) + GetFibonacci(n - 1);
        }
    }
}