namespace _12.CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            long sum = MultiplyChars(input[0], input[1]);
            Console.WriteLine(sum);
        }

        private static long MultiplyChars(string first, string second)
        {
            long sum = 0;

            if (first.Length > second.Length)
            {
                string temp = first;
                first = second;
                second = temp;
            }

            for (int i = 0; i < first.Length; i++)
            {
                sum += first[i] * second[i];
            }

            for (int i = first.Length; i < second.Length; i++)
            {
                sum += second[i];
            }

            return sum;
        }
    }
}
