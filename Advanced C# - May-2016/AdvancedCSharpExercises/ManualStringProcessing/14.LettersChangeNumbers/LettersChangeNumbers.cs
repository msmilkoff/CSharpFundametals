namespace _14.LettersChangeNumbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var words = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0.0m;
            foreach (var word in words)
            {
                totalSum += GetSum(word);
            }

            Console.WriteLine("{0:0.00}", totalSum);

        }

        private static decimal GetSum(string word)
        {
            char firstLetter = word[0];
            char lastLetter = word[word.Length - 1];
            decimal number = decimal.Parse(word.Substring(1, word.Length - 2));

            // Mod 32 gets the position of the letter in the alphabet
            int firstLetterPos = firstLetter % 32;
            int lastLetterPos = lastLetter % 32;
            if (char.IsUpper(firstLetter))
            {
                number /= firstLetterPos;
            }
            else
            {
                number *= firstLetterPos;
            }

            if (char.IsUpper(lastLetter))
            {
                number -= lastLetterPos;
            }
            else
            {
                number += lastLetterPos;
            }

            return number;
        }
    }
}
