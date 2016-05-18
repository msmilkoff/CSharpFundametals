namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main(string[] args)
        { 
            var symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            foreach (var symbol in input)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 1);
                }
                else
                {
                    symbols[symbol]++;
                }
            }

            foreach (var entry in symbols)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} time/s");
            }
        }
    }
}