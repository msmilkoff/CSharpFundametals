namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOps
    {
        public static void Main(string[] args)
        {
            var input = ReadIntArray();
            
            int dequeueCount = input[1];
            int elementToFind = input[2];

            var numbers = ReadIntArray();

            var elements = new Queue<int>();

            foreach (var number in numbers)
            {
                elements.Enqueue(number);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                elements.Dequeue();
            }

            string output = elements.Contains(elementToFind)
                ? "true"
                : elements.Any() 
                    ? (elements.Min().ToString()) 
                    : "0";

            Console.WriteLine(output);
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}