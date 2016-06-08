namespace _02.KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> prefixPrint = name => Console.WriteLine("Sir " + name);

            foreach (var name in names)
            {
                prefixPrint(name);
            }
        }
    }
}