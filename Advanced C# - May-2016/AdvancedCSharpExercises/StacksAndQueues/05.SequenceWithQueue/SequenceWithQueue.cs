namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceWithQueue
    {
        public static void Main(string[] args)
        {
            long element = long.Parse(Console.ReadLine());

            var sequence = new Queue<long>();
            sequence.Enqueue(element);

            var outputValues = new List<long>();
            outputValues.Add(element);
            while (outputValues.Count < 50)
            {
                long firstElement = sequence.Peek() + 1;
                sequence.Enqueue(firstElement);

                long secondElement = 2 * sequence.Peek() + 1;
                sequence.Enqueue(secondElement);

                long thirdElement = sequence.Peek() + 2;
                sequence.Enqueue(thirdElement);

                sequence.Dequeue();

                outputValues.Add(firstElement);
                outputValues.Add(secondElement);
                outputValues.Add(thirdElement);
            }

            Console.WriteLine(string.Join(" ", outputValues.Take(50)));
        }
    }
}