namespace _03.Ferrari
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string driver = Console.ReadLine();

            ICar car = new Car(driver);
            Console.WriteLine(car);
        }
    }

    public class Car : ICar
    {
        private const string FerrariModel = "488-Spider";

        public Car(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; private set; }

        public string Model => FerrariModel;

        public string Break()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            string result = $"{this.Model}/{this.Break()}/{this.PushGas()}/{this.Driver}";

            return result;
        }
    }

    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string Break();

        string PushGas();
    }
}
