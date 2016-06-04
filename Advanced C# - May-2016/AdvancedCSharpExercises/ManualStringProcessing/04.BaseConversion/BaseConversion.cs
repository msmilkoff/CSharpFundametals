namespace _05.BaseNToBaseTen
{
    using System;
    using System.Numerics;

    public class BaseConversion
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            int @base = int.Parse(input[0]);
            string number = input[1];
            if (@base == 10)
            {
                Console.WriteLine(number);
                return;
            }

            Console.WriteLine(ConvertToDecimal(number, @base));
        }

        private static BigInteger ConvertToDecimal(string number, int @base)
        {
            var result = BigInteger.Zero;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                int currentExponent = number.Length - i - 1;

                result += currentDigit * PowerUp(@base, currentExponent);
            }

            return result;
        }

        private static BigInteger PowerUp(BigInteger number, int exponent)
        {
            if (exponent < 0)
            {
                return -1; // invalid exponent
            }
            else if (exponent == 1)
            {
                return number;
            }
            else if (exponent == 0)
            {
                return 1;
            }
            else
            {
                return number * PowerUp(number, exponent - 1);
            }
        }
    }
}
