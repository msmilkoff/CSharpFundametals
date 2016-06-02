namespace _05.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main(string[] args)
        {
            const string pattern = @"^|\s([a-z]+[a-z\.-]+[a-z]+@[a-z]+[a-z-.]+\.[a-z]+)";

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                var matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[1].Value);
                }

                input = Console.ReadLine();
            }
        }
    }
}
