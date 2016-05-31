namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;

    public class Palindromes
    {
        public static void Main(string[] args)
        {
            char[] delimiters = { ' ', ',', '.', '?', '!' };

            string[] input = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new SortedSet<string>();
            foreach (var word in input)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", palindromes)}]");
        }

        private static bool IsPalindrome(string word)
        {
            int rightIndex = word.Length - 1;
            int leftIndex = 0;

            while (rightIndex >= leftIndex)
            {
                if (word[rightIndex] != word[leftIndex])
                {
                    return false;
                }

                rightIndex--;
                leftIndex++;
            }

            return true;
        }
    }
}
