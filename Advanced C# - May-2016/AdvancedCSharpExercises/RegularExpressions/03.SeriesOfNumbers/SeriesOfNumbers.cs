namespace _03.SeriesOfNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var regex = new Regex(@"(.)\1+");

            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}
