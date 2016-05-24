namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PopulationCounter
    {
        public static void Main(string[] args)
        {
            var populationByCountries = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] inputArgs = input.Split('|');
                string country = inputArgs[1];
                string city = inputArgs[0];
                long population = long.Parse(inputArgs[2]);

                if (!populationByCountries.ContainsKey(country))
                {
                    populationByCountries.Add(country, new Dictionary<string, long>());
                }

                if (!populationByCountries[country].ContainsKey(city))
                {
                    populationByCountries[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            var sortedCountries = populationByCountries
                .OrderByDescending(x => x.Value.Values.Sum());

            foreach (var country in sortedCountries)
            {
                var sortedCities = country.Value
                    .OrderByDescending(x => x.Value);

                long totalPopulation = country.Value.Sum(x => x.Value);
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
