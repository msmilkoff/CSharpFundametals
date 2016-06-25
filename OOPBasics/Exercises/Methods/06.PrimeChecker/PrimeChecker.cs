namespace _06.PrimeChecker
{
    using System;

    public class PrimeChecker
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var number = new Number(n);
            number.Print();
        }
    }

    public class Number
    {
        private int value;
        private bool isPrime;

        public Number(int value)
        {
            this.value = value;
            this.isPrime = CheckForPrime(value);
        }

        public int Value => this.value;

        public int NextPrime => GetNextPrime(this.value);

        public bool IsPrime => this.isPrime;

        private bool CheckForPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1)
            {
                return false;
            }

            if (number == 2 || number == 0)
            {
                return true;
            }

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private int GetNextPrime(int number)
        {
            bool isPrime = false;
            int i = number + 1;
            for (; i < 2 * number; ++i)
            {
                if (this.CheckForPrime(i))
                {
                    isPrime = true;
                    break;
                }
            }

            return i;
        }

        public void Print()
        {
            Console.WriteLine($"{this.NextPrime}, {this.isPrime.ToString().ToLower()}");
        }
    }
}
