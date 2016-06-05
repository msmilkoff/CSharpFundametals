using System;
using System.Text.RegularExpressions;

namespace _04.ReplaceTag
{
    class ReplaceAHrefTag
    {
        static void Main()
        {
            const string pattern = @"<a([\w\W]*)>([\w\W]*)<\/a>";

            string html = Console.ReadLine();
            while (html != "end")
            {
                var match = Regex.Match(html, pattern);

                string result =
                    match.Groups[1].Value
                    + "[URL href=" + match.Groups[3].Value + "]"
                    + match.Groups[5].Value + "[/URL]"
                    + match.Groups[7].Value;

                Console.WriteLine(result);

                html = Console.ReadLine();
            }
        }
    }
}