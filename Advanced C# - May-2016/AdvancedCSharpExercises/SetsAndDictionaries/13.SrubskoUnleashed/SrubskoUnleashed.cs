namespace _13.SrubskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class SrubskoUnleashed
    {
        public static void Main(string[] args)
        {
            const string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            var venues = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var match = Regex.Match(input, pattern);
                string venueName = match.Groups[2].Value;
                string singerName = match.Groups[1].Value;
                int ticketPrice = int.Parse(match.Groups[3].Value);
                int ticketCount = int.Parse(match.Groups[4].Value);
                long totalMoney = (long)ticketCount * ticketPrice;

                if (!venues.ContainsKey(venueName))
                {
                    venues.Add(venueName, new Dictionary<string, long>());
                }

                if (!venues[venueName].ContainsKey(singerName))
                {
                    venues[venueName].Add(singerName, 0);
                }
                
                venues[venueName][singerName] += totalMoney;

                input = Console.ReadLine();
            }

            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);

                var sortedSingers = venue.Value
                    .OrderByDescending(s => s.Value)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var singer in sortedSingers)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
