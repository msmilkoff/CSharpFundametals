namespace _01.ReverseString
{
    using System;

    public class ReverseString
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(Reverse(input));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
