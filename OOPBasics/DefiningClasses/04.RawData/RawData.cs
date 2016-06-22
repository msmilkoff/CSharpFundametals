namespace _04.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        public static void Main()
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split();

                string carModel = inputArgs[0];
                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]);
                var engine = new CarEgine(enginePower, enginePower);

                int cargoWeight = int.Parse(inputArgs[3]);
                string cargoType = inputArgs[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(inputArgs[5]);
                int tire1Age = int.Parse(inputArgs[6]);
                double tire2Pressure = double.Parse(inputArgs[7]);
                int tire2Age = int.Parse(inputArgs[8]);
                double tire3Pressure = double.Parse(inputArgs[9]);
                int tire3Age = int.Parse(inputArgs[10]);
                double tire4Pressure = double.Parse(inputArgs[11]);
                int tire4Age = int.Parse(inputArgs[12]);

                var tires = new List<Tire>
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                var car = new Car(carModel, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            IEnumerable<string> wantedCars = null;
            if (command == "fragile")
            {
                wantedCars = cars
                    .Where(c => c.Cargo.Type == "fragile" &&
                        c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model);
            }

            else if (command == "flamable")
            {
                wantedCars = cars
                    .Where(c => c.Cargo.Type == "flamable" &&
                        c.Engine.Power > 250)
                    .Select(c => c.Model);
            }

            Console.WriteLine(string.Join("\n", wantedCars));
        }

        public class CarEgine
        {
            public CarEgine(int speed, int power)
            {
                this.Speed = speed;
                this.Power = power;
            }

            public int Speed { get; set; }

            public int Power { get; set; }
        }

        public class Tire
        {
            public Tire(double pressure, int age)
            {
                this.Pressure = pressure;
                this.Age = age;
            }

            public int Age { get; set; }

            public double Pressure { get; set; }
        }

        public class Cargo
        {
            public Cargo(int weight, string type)
            {
                this.Weight = weight;
                this.Type = type;
            }

            public int Weight { get; set; }

            public string Type { get; set; }
        }

        public class Car
        {
            public Car(string model, CarEgine engine, Cargo cargo, List<Tire> tires)
            {
                this.Model = model;
                this.Cargo = cargo;
                this.Engine = engine;
                this.Tires = tires;
            }

            public string Model { get; set; }

            public Cargo Cargo { get; set; }

            public CarEgine Engine { get; set; }

            public List<Tire> Tires { get; set; }
        }
    }
}