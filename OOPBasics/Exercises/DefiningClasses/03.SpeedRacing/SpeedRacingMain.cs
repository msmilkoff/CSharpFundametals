namespace _03.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpeedRacingMain
    {
        public static void Main()
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuel = double.Parse(input[1]);
                double fuelConsumtion = double.Parse(input[2]);

                var car = new Car(model, fuel, fuelConsumtion);
                cars.Add(car);
            }

            while (true)
            {
                string[] driveCommand = Console.ReadLine().Split();
                if (driveCommand[0] == "End")
                {
                    break;
                }

                string carModel = driveCommand[1];
                int amountOfKm = int.Parse(driveCommand[2]);

                var carToDrive = cars.First(c => c.Model == carModel);
                carToDrive.Drive(amountOfKm);
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTravelled}");
            }
        }
    }

    public class Car
    {
        private const double InitialDistanceTravelled = 0;

        public Car(string model, double fuelAmount, double fuelCostPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelCostPerKm = fuelCostPerKm;
            this.DistanceTravelled = InitialDistanceTravelled;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelCostPerKm { get; set; }

        public double DistanceTravelled { get; set; }

        public void Drive(int amountOfKm)
        {
            if (amountOfKm <= this.FuelAmount / this.FuelCostPerKm)
            {
                this.DistanceTravelled += amountOfKm;
                this.FuelAmount -= this.FuelCostPerKm * amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
