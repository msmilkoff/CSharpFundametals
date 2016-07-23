namespace _04.Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var stones = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var result = new List<int>();

            var lake = new Lake(stones);
            foreach (var stone in lake)
            {
                result.Add(stone);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }

    public class Lake : IEnumerable<int>
    {
        private readonly int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.stones[i];
                }
            }

            for (int i = this.stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
