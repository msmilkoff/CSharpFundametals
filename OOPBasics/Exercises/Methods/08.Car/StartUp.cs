namespace _08.Car
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var car = new Car(carInfo[0], carInfo[1], carInfo[2]);

            while (true)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "Travel":
                        car.Travel(double.Parse(command[1]));
                        break;
                    case "Refuel":
                        car.Refuel(double.Parse(command[1]));
                        break;
                    case "Distance":
                        Console.WriteLine($"Total distance: {car.TotalDistance:F1} kilometers");
                        break;
                    case "Time":
                        Console.WriteLine($"Total time: {car.TotalTime / 60} hours and {car.TotalTime % 60} minutes");
                        break;
                    case "Fuel":
                        Console.WriteLine($"Fuel left: {car.Fuel:F1} liters");
                        break;
                    case "END":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    public class Car
    {
        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.Speed = speed;
            this.Fuel = fuel;
            this.FuelEconomy = fuelEconomy;
        }

        public double Speed { get; set; }

        public double Fuel { get; set; }

        public double FuelEconomy { get; set; }

        public double TotalDistance { get; set; }

        public long TotalTime { get; set; } // in minutes

        public void Refuel(double amount)
        {
            this.Fuel += amount;
        }

        public void Travel(double distance)
        {
            double neededFuel = distance / 100 * this.FuelEconomy;
            if (this.Fuel >= neededFuel)
            {
                this.Fuel -= neededFuel;
                this.TotalDistance += distance;

                this.TotalTime += (long)(distance / this.Speed * 60);
            }
            else
            {
                double maxPossibleDistance = 100 / this.FuelEconomy * this.Fuel;
                this.TotalDistance += maxPossibleDistance;
                this.Fuel = 0;

                this.TotalTime += (long)(maxPossibleDistance / this.Speed * 60);
            }
        }
    }
}
