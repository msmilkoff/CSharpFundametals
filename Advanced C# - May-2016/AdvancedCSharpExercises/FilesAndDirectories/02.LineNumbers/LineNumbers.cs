namespace _02.LineNumbers
{
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        public static void Main(string[] args)
        {
            string path = @"../../../Tests/03_LineNumbers/01_LinesIn.txt";

            var lines = File.ReadAllLines(path).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = $"{i + 1}. " + lines[i];
            }

            File.WriteAllLines(@"../../../LineNumbersOutput.txt", lines);
        }
    }
}
