namespace _06.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();

            const string pattern = @".*?[!.?]";

            foreach (Match match in Regex.Matches(text, pattern))
            {
                if (match.Value.Contains(" " + keyword + " "))
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}