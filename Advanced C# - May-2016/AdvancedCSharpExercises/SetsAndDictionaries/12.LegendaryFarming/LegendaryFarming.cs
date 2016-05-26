namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };

            bool legendayCollected = false;

            string input = Console.ReadLine().ToLower();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var inputArgs = input.Split(' ');

                for (int i = 1; i < inputArgs.Length; i += 2)
                {
                    if (!materials.ContainsKey(inputArgs[i]))
                    {
                        materials.Add(inputArgs[i], 0);
                    }

                    materials[inputArgs[i]] += int.Parse(inputArgs[i - 1]);
                    if (materials["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        materials["shards"] -= 250;
                        legendayCollected = true;
                        break;
                    }
                    else if (materials["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        materials["fragments"] -= 250;
                        legendayCollected = true;
                        break;
                    }
                    else if (materials["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        materials["motes"] -= 250;
                        legendayCollected = true;
                        break;
                    }
                }

                if (legendayCollected)
                {
                    break;
                }

                input = Console.ReadLine().ToLower();
            }

            // Gets new dictionary from the main one containing the key materials and sorts it
            var remainingKeyMaterials = materials
                .Where(
                    x => x.Key == "shards" ||
                    x.Key == "fragments" ||
                    x.Key == "motes")
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var material in remainingKeyMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            /* Removing the already printed materials in order to use
               different sorting for the junk materials */

            materials.Remove("shards");
            materials.Remove("fragments");
            materials.Remove("motes");

            var sortedMaterials = materials
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var material in sortedMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
