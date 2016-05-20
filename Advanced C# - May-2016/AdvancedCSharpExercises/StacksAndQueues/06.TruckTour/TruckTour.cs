namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;

    public class TruckTour
    {
        public static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            var truck = new Queue<Pump>();
            for (int i = 0; i < pumpsCount; i++)
            {
                string[] pumpInfo = Console.ReadLine().Split();
                int amount = int.Parse(pumpInfo[0]);
                int distanceToNext = int.Parse(pumpInfo[1]);

                var currentPump = new Pump(amount, distanceToNext, i);
                truck.Enqueue(currentPump);
            }

            while (true)
            {
                var currentPump = truck.Dequeue();
                truck.Enqueue(currentPump);

                var startingPump = currentPump;
                int gasInPump = currentPump.Amount;

                bool canFinishTour = false;
                while (gasInPump >= currentPump.DistanceToNext)
                {
                    gasInPump -= currentPump.DistanceToNext;

                    currentPump = truck.Dequeue();
                    truck.Enqueue(currentPump);
                    if (currentPump == startingPump)
                    {
                        canFinishTour = true;
                        break;
                    }

                    gasInPump += currentPump.Amount;
                }

                if (canFinishTour)
                {
                    Console.WriteLine(startingPump.PumpIndex);
                    break;
                }
            }
        }

        public class Pump
        {
            public int Amount { get; set; }

            public int DistanceToNext { get; set; }

            public int PumpIndex { get; set; }

            public Pump(int amount, int distanceToNext, int pumpIndex)
            {
                this.Amount = amount;
                this.DistanceToNext = distanceToNext;
                this.PumpIndex = pumpIndex;
            }
        }
    }
}