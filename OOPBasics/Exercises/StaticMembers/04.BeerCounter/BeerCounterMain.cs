namespace _04.BeerCounter
{
    using System;
    using System.Linq;

    public class BeerCounterMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                int[] bottleInfo = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                BeerCounter.BuyBeer(bottleInfo[0]);
                BeerCounter.DrinkBeer(bottleInfo[1]);

                input = Console.ReadLine();
            }

            int[] beerResults = BeerCounter.GetBeerInfo();

            Console.WriteLine($"{beerResults[0]} {beerResults[1]}");
        }
    }

    public class BeerCounter
    {
        private static int beerInStock;
        private static int beerDrankCount;

        public static void BuyBeer(int bottlesCount)
        {
            beerInStock += bottlesCount;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            beerInStock -= bottlesCount;
            beerDrankCount += bottlesCount;
        }

        public static int[] GetBeerInfo()
        {
            return new[] { beerInStock, beerDrankCount };
        }
    }
}
