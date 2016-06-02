using System;
using System.Text.RegularExpressions;

class ReplaceAHrefTag
{
    static void Main()
    {
        string html = Console.ReadLine();
        string pattern = "<a(\\shref=.+)>(.+)<\\/a>";

        while (html != "end")
        {
            Console.WriteLine(Regex.Replace(html, pattern, @"[URL href=$1]$2[/URL]"));
        }
    }
}