namespace _03.FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(inputArgs[0]);
            double b = double.Parse(inputArgs[1]);
            double c = double.Parse(inputArgs[2]);

            string aHex = a.ToString("X").PadRight(10);
            string aBin = Convert.ToString(a, 2).PadLeft(10, '0');
            if (aBin.Length > 10)
            {
                aBin = aBin.Substring(0, 10);
            }

            string bRounded = b.ToString("0.00");
            string cRounded = c.ToString("0.000");

            Console.WriteLine("|{0}|{1}|{2, 10}|{3, -10}|", aHex, aBin, bRounded, cRounded);
        }
    }
}
