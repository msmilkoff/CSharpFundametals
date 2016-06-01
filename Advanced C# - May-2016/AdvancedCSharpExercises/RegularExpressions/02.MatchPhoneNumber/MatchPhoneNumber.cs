namespace _02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main(string[] args)
        {
            const string pattern = @"(\+359-2-\d{3}-\d{4}\b)|((\+359 2 \d{3} \d{4}\b))";

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
