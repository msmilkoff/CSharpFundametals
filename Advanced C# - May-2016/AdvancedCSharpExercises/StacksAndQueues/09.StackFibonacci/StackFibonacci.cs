namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var fibNumbers = new Stack<ulong>();
            fibNumbers.Push(1);
            fibNumbers.Push(1);

            for (int i = 1; i < n; i++)
            {
                ulong first = fibNumbers.Pop();
                ulong second = fibNumbers.Pop();

                fibNumbers.Push(first);
                fibNumbers.Push(first + second);
            }

            fibNumbers.Pop();
            Console.WriteLine(fibNumbers.Peek());
        }
    }
}