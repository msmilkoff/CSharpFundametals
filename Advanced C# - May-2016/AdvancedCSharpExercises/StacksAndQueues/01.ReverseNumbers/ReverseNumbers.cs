namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = new Stack<int>();
            foreach (var number in input)
            {
                numbers.Push(number);
            }

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
