namespace _01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main(string[] args)
        {
            const string pattern = @"[A-Z]\w+ [A-Z]\w+";

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