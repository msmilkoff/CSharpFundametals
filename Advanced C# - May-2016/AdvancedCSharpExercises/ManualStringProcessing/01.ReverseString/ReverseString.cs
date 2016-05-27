namespace _01.ReverseString
{
    using System;

    public class ReverseString
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }

            Console.WriteLine();
        }
    }
}
