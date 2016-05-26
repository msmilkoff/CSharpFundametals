namespace _01.OddLines
{
    using System.Collections.Generic;
    using System.IO;

    public class OddLines
    {
        public static void Main(string[] args)
        {
            string path =
                @"C:\SoftUni\C# Fundamentals\Advanced C# - May-2016\AdvancedCSharpExercises\FilesAndDirectories\Tests\02_OddLines\01_OddLinesIn.txt";

            var oddLines = new List<string>();

            string[] text = File.ReadAllLines(path);
            for (int i = 1; i < text.Length; i += 2)
            {
                oddLines.Add(text[i]);
            }

            File.WriteAllLines("../../../OddLinesOutput.txt", oddLines);
        }
    }
}
