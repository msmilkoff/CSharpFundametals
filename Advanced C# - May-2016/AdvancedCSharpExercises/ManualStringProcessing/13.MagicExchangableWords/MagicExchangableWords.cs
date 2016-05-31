namespace _13.MagicExchangableWords
{
    using System;
    using System.Collections.Generic;

    public class MagicExchangableWords
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split();

            if (words[0].Length > words[1].Length)
            {
                string temp = words[0];
                words[0] = words[1];
                words[1] = temp;
            }

            var wordMap = new Dictionary<char, char>();
            for (int i = 0; i < words[0].Length; i++)
            {
                char firstWordChar = words[0][i];
                char secondWordChar = words[1][i];

                if (!wordMap.ContainsKey(firstWordChar))
                {
                    wordMap.Add(firstWordChar, secondWordChar);
                }
                else if(wordMap[firstWordChar] != secondWordChar)
                {
                    Console.WriteLine("false");
                    return;
                }
            }

            Console.WriteLine("true");
        }
        
    }
}
