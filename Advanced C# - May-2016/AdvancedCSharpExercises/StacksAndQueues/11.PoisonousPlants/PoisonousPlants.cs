namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main(string[] args)
        {
            string unneededInfo = Console.ReadLine(); // ha ha

            var pesticides = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var plants = new Stack<Plant>();
            var maxDaysAlive = 0;

            foreach (var pesticide in pesticides)
            {
                var daysAlive = 0;
                while (plants.Count > 0 && pesticide <= plants.Peek().Poison)
                {
                    daysAlive = Math.Max(daysAlive, plants.Pop().DaysAlive);
                }

                daysAlive = plants.Count == 0 ? 0 : daysAlive + 1;
                maxDaysAlive = Math.Max(maxDaysAlive, daysAlive);

                var plant = new Plant(pesticide, daysAlive);
                plants.Push(plant);
            }

            Console.WriteLine(maxDaysAlive);
        }
    }

    public struct Plant
    {
        public Plant(int poison, int daysAlive)
        {
            this.Poison = poison;
            this.DaysAlive = daysAlive;
        }

        public int Poison { get; }

        public int DaysAlive { get; }
    }
}