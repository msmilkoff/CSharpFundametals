namespace _04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main(string[] args)
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int min = range[0];
            int max = range[1];
            int[] nums = Enumerable.Range(min, max - min + 1).ToArray();

            var result = new List<int>();
            if (command == "odd")
            {
                result = CustomWhere(nums, n => n % 2 != 0) as List<int>;
            }
            else if (command == "even")
            {
                result = CustomWhere(nums, n => n % 2 == 0) as List<int>;
            }

            Console.WriteLine(result == null ? "" : string.Join(" ", result));
        }

        public static IEnumerable<int> CustomWhere(IEnumerable<int> collection, Predicate<int> condition)
        {
            var result = new List<int>();
            foreach (int number in collection)
            {
                if (condition(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}