namespace _10.UnicodeCharacters
{
    using System;
    using System.Text;

    public class UnicodeCharacters
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var unicodeValues = new StringBuilder();
            foreach (int @char in input)
            {
                unicodeValues.Append("\\u");
                unicodeValues.Append(string.Format($"{@char:x4}"));
            }

            Console.WriteLine(unicodeValues.ToString());
        }
    }
}
