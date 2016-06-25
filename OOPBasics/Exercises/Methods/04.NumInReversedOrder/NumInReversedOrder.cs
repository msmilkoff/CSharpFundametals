namespace _04.NumInReversedOrder
{
    using System;

    public class NumInReversedOrder
    {
        public static void Main()
        {
            string input = Console.ReadLine().Trim();

            var decimalNumber = new DecimalNumber(input);
            string result = decimalNumber.Reverse();
            Console.WriteLine(result);
        }
    }

    public class DecimalNumber
    {
        public DecimalNumber(string number)
        {
            this.number = number;
        }

        private string number;

        public string Number => this.number;

        public string Reverse()
        {
            var numArray = number.ToCharArray();
            Array.Reverse(numArray);

            return new string(numArray);
        }
    }
}
