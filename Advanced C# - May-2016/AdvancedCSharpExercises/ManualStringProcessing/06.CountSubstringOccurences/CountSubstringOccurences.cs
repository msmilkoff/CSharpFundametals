namespace _06.CountSubstringOccurences
{
    using System;

    public class CountSubstringOccurences
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string searchString = Console.ReadLine().ToLower();

            int result = input.Split(new[] { searchString }, StringSplitOptions.None).Length - 1;

            Console.WriteLine(result);
        }
    }
}
