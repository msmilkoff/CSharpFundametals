namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main(string[] args)
        {
            // TODO: Optimize for maximum result in Judge.
            var cardsByPlayer = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] inputArgs = input.Trim().Split(
                    new[] { ':', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string playerName = inputArgs[0];
                var handOfCards = new HashSet<string>();
                for (int i = 1; i < inputArgs.Length; i++)
                {
                    handOfCards.Add(inputArgs[i]);
                }

                if (!cardsByPlayer.ContainsKey(playerName))
                {
                    cardsByPlayer.Add(playerName, handOfCards);
                }
                else
                {
                    AddHandToPlayer(handOfCards, cardsByPlayer, playerName);
                }

                input = Console.ReadLine();
            }

            foreach (var playerHandPair in cardsByPlayer)
            {
                int points = CalculateHand(playerHandPair);
                Console.WriteLine($"{playerHandPair.Key}: {points}");
            }
        }

        private static int CalculateHand(KeyValuePair<string, HashSet<string>> playerHandPair)
        {
            int points = 0;

            foreach (var card in playerHandPair.Value)
            {
                int power, multiplier = 0;

                if (card.Length == 3)
                {
                    power = 10;
                }
                else
                {
                    switch (card[0])
                    {
                        case 'J':
                            power = 11;
                            break;
                        case 'Q':
                            power = 12;
                            break;
                        case 'K':
                            power = 13;
                            break;
                        case 'A':
                            power = 14;
                            break;
                        default:
                            power = int.Parse(card[0].ToString());
                            break;
                    }
                }

                switch (card.Last())
                {
                    case 'S':
                        multiplier = 4;
                        break;
                    case 'H':
                        multiplier = 3;
                        break;
                    case 'D':
                        multiplier = 2;
                        break;
                    case 'C':
                        multiplier = 1;
                        break;
                }

                points += power * multiplier;
            }

            return points;
        }

        private static void AddHandToPlayer(HashSet<string> handOfCards, Dictionary<string, HashSet<string>> cardsByPlayer, string playerName)
        {
            foreach (var hand in handOfCards)
            {
                if (!cardsByPlayer[playerName].Contains(hand))
                {
                    cardsByPlayer[playerName].Add(hand);
                }
            }
        }
    }
}