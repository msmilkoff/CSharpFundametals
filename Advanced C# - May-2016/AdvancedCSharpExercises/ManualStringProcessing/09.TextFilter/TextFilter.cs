namespace _09.TextFilter
{
    using System;
    using System.Linq;
    using System.Text;

    public class TextFilter
    {
        public static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine()
                .Split(',')
                .Select(w => w.Trim())
                .ToArray();

            string input = Console.ReadLine();

            var text = new StringBuilder(input);

            foreach (var bannedWord in bannedWords)
            {
                string mask = new string('*', bannedWord.Length);
                text.Replace(bannedWord, mask);
            }

            Console.WriteLine(text.ToString());
        }
    }
}
