namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;

    public class TruckTour
    {
        public static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            var truck  = new Queue<int>();
            for (int i = 0; i < pumpsCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Trim().Split();

                var petrolAmount = int.Parse(inputArgs[0]);
                var distance = int.Parse(inputArgs[1]);

                truck.Enqueue(petrolAmount);
                // TODO: the rest
            }
        }
    }
}