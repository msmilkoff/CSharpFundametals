namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class HandsOfCards
    {
        public static void Main()
        {
            var multipliers = new Dictionary<string, int> { { "S", 4 }, { "H", 3 }, { "D", 2 }, { "C", 1 } };
            var powers = new Dictionary<string, int> { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };

            var cardsByPlayer = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] inputArgs = Regex.Replace(input, "\\s+", "")
                    .Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                string[] cards = inputArgs.Skip(1).ToArray();

                if (!cardsByPlayer.ContainsKey(name))
                {
                    cardsByPlayer.Add(name, new HashSet<string>(cards));
                }
                else
                {
                    foreach (var card in cards)
                    {
                        cardsByPlayer[name].Add(card);
                    }
                }

                input = Console.ReadLine();
            }

            var output = new StringBuilder();
            foreach (var deck in cardsByPlayer)
            {
                long points = GetPoints(deck.Value, powers, multipliers);

                output.AppendLine($"{deck.Key}: {points}");
            }

            Console.Write(output.ToString());
        }

        private static long GetPoints(
            HashSet<string> cards,
            Dictionary<string, int> powers,
            Dictionary<string, int> multipliers)
        {
            long points = 0;
            foreach (var card in cards)
            {
                int power;
                if (card.Length == 3)
                {
                    power = 10;
                }
                else
                {
                    bool canGetPower = powers.TryGetValue(card[0].ToString(), out power);
                    if (!canGetPower)
                    {
                        power = int.Parse(card.Substring(0, 1));
                    }
                }
                
                string suite = card[card.Length - 1].ToString();
                points += power * multipliers[suite];
            }

            return points;
        }
    }
}