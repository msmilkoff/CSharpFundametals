namespace _07.SumBigNumbers
{
    using System;
    using System.Numerics;

    public class SumBigNumbers
    {
        public static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNum = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(firstNum + secondNum);
        }
    }
}
