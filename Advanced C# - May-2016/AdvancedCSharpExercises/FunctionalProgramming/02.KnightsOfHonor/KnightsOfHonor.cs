namespace _02.KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

           // Action<List<string> prefixPrint = names => Console.WriteLine("Sir " + names);
        }
    }
}