namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> getMin = nums => nums.Min();

            Console.WriteLine(getMin(numbers));
        }
    }
}