namespace BashSoft.Judge
{
    using System;
    using System.IO;
    using Exceptions;
    using IO;
    using Static_Data;

    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                string mismatchPath = this.GetMismatchPath(expectedOutputPath);

                string[] actualOutput = File.ReadAllLines(userOutputPath);
                string[] expectedOutput = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = this.GetLinesWithPossibleMismatches(actualOutput, expectedOutput, out hasMismatch);

                this.PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException)
            {
                throw new IOException(InvalidPathException.InvalidPath);
            }
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                File.WriteAllLines(mismatchPath, mismatches);
                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private string[] GetLinesWithPossibleMismatches(
            string[] actualOutput,
            string[] expectedOutput,
            out bool hasMismatch)
        {
            hasMismatch = false;

            string[] mismatches = new string[actualOutput.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutput.Length;
            if (actualOutput.Length != expectedOutput.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutput.Length, expectedOutput.Length);
            }

            for (int i = 0; i < minOutputLines; i++)
            {
                string actualLine = actualOutput[i];
                string expectedLine = expectedOutput[i];

                string output;
                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format("Mismatch at line {0} -- expected \"{1}\", actual: \" {2}\"",
                        i, expectedLine, actualLine);
                    output += Environment.NewLine;

                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        public string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.IndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";

            return finalPath;
        }
    }
}