namespace _07.ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            const string pattern = @"(?:^|\s)([a-zA-Z][a-zA-Z0-9_]*)(?:$|\s)";

            string input = Console.ReadLine();

            var usernames = input
                .Split(new[] { '\\', '/', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            usernames = usernames
                .Where(u => u.Length >= 3 && u.Length <= 25 && Regex.IsMatch(u, pattern))
                .ToList();

            var coordsBySum = new Dictionary<int, Coord>();
            for (int i = 0; i < usernames.Count - 1; i++)
            {
                int sum = usernames[i].Length + usernames[i + 1].Length;

                if (!coordsBySum.ContainsKey(sum))
                {
                    coordsBySum.Add(sum, new Coord(i, i + 1));
                }
            }

            var result = coordsBySum.Keys.Max();
            int firstIndex = coordsBySum[result].CoordOfFirstWord;
            int secondIndex = coordsBySum[result].CoordOfSecondWord;

            Console.WriteLine(usernames[firstIndex]);
            Console.WriteLine(usernames[secondIndex]);
        }
    }

    public struct Coord
    {
        public Coord(int coordOfFirstWord, int coordOfSecondWord)
        {
            this.CoordOfFirstWord = coordOfFirstWord;
            this.CoordOfSecondWord = coordOfSecondWord;
        }

        public int CoordOfFirstWord { get; set; }

        public int CoordOfSecondWord { get; set; }
    }
}
