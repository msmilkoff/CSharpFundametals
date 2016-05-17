namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main(string[] args)
        {
            var input = ReadIntArray();

            int elemetsCount = input[0];
            int popCount = input[1];
            int elementToFind = input[2];

            var elements = new Stack<int>();
            var numbers = Console.ReadLine().Split();
            for (int i = 0; i < elemetsCount; i++)
            {
                elements.Push(int.Parse(numbers[i]));
            }

            for (int i = 0; i < popCount; i++)
            {
                elements.Pop();
            }

            // ternaryception
            string result =
                elements.Count == 0
                ? "0"
                : elements.Contains(elementToFind)
                    ? "true"
                    : elements.Min().ToString();

            Console.WriteLine(result);
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
