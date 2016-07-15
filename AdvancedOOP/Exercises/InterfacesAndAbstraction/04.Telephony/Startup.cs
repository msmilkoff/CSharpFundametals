namespace _04.Telephony
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            var phone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    phone.Call(number);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    phone.Browse(url);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class Smartphone : ICaller, IBrowser
    {
        public void Call(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");
        }
    }

    public interface IBrowser
    {
        void Browse(string url);
    }

    public interface ICaller
    {
        void Call(string phoneNumber);
    }
}
