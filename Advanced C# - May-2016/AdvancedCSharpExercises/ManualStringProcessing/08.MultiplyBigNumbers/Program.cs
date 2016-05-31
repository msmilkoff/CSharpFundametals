namespace _07.SumBigNumbers
{
    using System;
    using System.Numerics;

    public class SumBigNumbers
    {
        public static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNum * secondNum);
        }
    }
}
