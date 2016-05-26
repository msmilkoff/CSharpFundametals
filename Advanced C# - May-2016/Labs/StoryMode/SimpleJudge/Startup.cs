namespace SimpleJudge
{
    using BashSoft;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string expected =
                @"C:\SoftUni\C# Fundamentals\Advanced C# - May-2016\AdvancedCSharpExercises\FilesAndDirectories\Tests\03_LineNumbers\01_LinesOut.txt";

            string actual = @"C:\SoftUni\C# Fundamentals\Advanced C# - May-2016\AdvancedCSharpExercises\FilesAndDirectories\LineNumbersOutput.txt";

            Tester.CompareContent(actual, expected);
        }
    }
}
