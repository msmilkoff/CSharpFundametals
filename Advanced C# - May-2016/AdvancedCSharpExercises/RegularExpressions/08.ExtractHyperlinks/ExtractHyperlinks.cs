namespace _08.ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks
    {
        public static void Main(string[] args)
        {
            const string pattern =  @"";

            var html = new StringBuilder();

            var input = Console.ReadLine().Trim();
            while (input != "END")
            {
                input = Regex.Replace(input, "\\s+", " ");
                html.Append(input);

                input = Console.ReadLine().Trim();
            }
        }
    }
}
