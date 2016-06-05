﻿namespace _15.MelrahShake
{
    using System;
    using System.Text;

    public class MelrahShake
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (input.Length > 0 && pattern.Length > 0)
            {
                int firstIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);

                if (firstIndex > -1 && lastIndex > -1 && firstIndex != lastIndex)
                {
                    var sb = new StringBuilder(input);
                    sb.Remove(lastIndex, pattern.Length);
                    sb.Remove(firstIndex, pattern.Length);
                    input = sb.ToString();

                    Console.WriteLine("Shaked it.");

                    sb = new StringBuilder(pattern);
                    sb.Remove(pattern.Length/2, 1);
                    pattern = sb.ToString();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }
    }
}
