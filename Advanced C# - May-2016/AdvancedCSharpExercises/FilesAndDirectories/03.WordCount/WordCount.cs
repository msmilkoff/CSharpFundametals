namespace _03.WordCount
{
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main(string[] args)
        {
            string textPath = @"../../../Tests/04_WordCount/text1.txt";
            string wordsPath = @"../../../Tests/04_WordCount/words1.txt";

            var text = File.ReadAllLines(textPath).ToList();
            var words = File.ReadAllLines(textPath).ToList();

            text.ForEach(x => x.Replace(" ", ""));
        }
    }
}
