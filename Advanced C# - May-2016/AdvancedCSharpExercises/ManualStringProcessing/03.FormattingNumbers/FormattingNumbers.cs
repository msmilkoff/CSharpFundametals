namespace _03.FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(inputArgs[0]);
            double b = double.Parse(inputArgs[1]);
            double c = double.Parse(inputArgs[2]);

            string result = string.Format("|{0, -10}|{1, 10}|{2, 10:F2}|{3, -10:F3}|",
                a.ToString("X"),
                Convert.ToString(a, 2).PadLeft(10, '0'),
                b,
                c);

            Console.WriteLine(result);

            // TODO: fix bugs.
        }
    }
}
