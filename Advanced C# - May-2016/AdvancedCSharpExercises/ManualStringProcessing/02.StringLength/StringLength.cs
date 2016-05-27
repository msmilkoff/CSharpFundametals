namespace _02.StringLength
{
    using System;
    using System.Linq;

    public class StringLength
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length < 20)
            {
                Console.WriteLine(input + new string('*', 20 - input.Length));
            }
            else
            {
                Console.WriteLine(string.Join("", input.Take(20)));
            }
        }
    }
}
