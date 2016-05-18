namespace _03.SetOfElements
{
    using System;
    using System.Collections.Generic;

    public class SetOfElements
    {
        public static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            var uniqueElements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                string[] elementSet = Console.ReadLine().Split();
                foreach (var element in elementSet)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}