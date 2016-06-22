namespace _05.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarSalesmanMain
    {
        public static void Main()
        {
            var engines = new Dictionary<string, Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] engineParams = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineParams[0];
                int enginePower = int.Parse(engineParams[1]);
                var engine = new Engine(engineModel, enginePower);

                if (engineParams.Length == 3)
                {
                    int displacement;
                    bool hasDisplacement = int.TryParse(engineParams[2], out displacement);
                    if (hasDisplacement)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineParams[2];
                    }
                }
                else if (engineParams.Length == 4)
                {
                    engine.Displacement = int.Parse(engineParams[2]);
                    engine.Efficiency = engineParams[3];
                }

                engines.Add(engineModel, engine);
            }

            var cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] carParams = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string carModel = carParams[0];
                string engineModel = carParams[1];
                var car = new Car(carModel, engines[engineModel]);

                if (carParams.Length == 3)
                {
                    int weight;
                    bool hasWeight = int.TryParse(carParams[2], out weight);
                    if (hasWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carParams[2];
                    }
                }
                else if (carParams.Length == 4)
                {
                    car.Weight = int.Parse(carParams[2]);
                    car.Color = carParams[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

    public class Engine
    {
        public Engine(string model, int power, int displacement = int.MinValue, string efficiency = "n/a")
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.Model}:");
            result.AppendLine($"    Power: {this.Power}");
            result.AppendLine(this.Displacement != int.MinValue
                ? $"    Displacement: {this.Displacement}"
                : "    Displacement: n/a");
            result.Append($"    Efficiency: {this.Efficiency}");

            return result.ToString();
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, int weight = int.MinValue, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.Model}:");
            result.AppendLine($"  {this.Engine}");
            result.AppendLine(this.Weight != int.MinValue
                ? $"  Weight: {this.Weight}"
                : "  Weight: n/a");
            result.Append($"  Color: {this.Color}");

            return result.ToString();
        }
    }
}
