namespace _01.Vehicles
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split();
                try
                {
                    switch (command[0])
                    {
                        case "Drive":
                            ExecuteDriveCommand(command, car, truck, bus);
                            break;
                        case "Refuel":
                            ExecuteRefuelCommand(command, car, truck, bus);
                            break;
                        case "DriveEmpty":
                            ExecuteDriveEmptyCommand(command, bus);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        private static void ExecuteDriveEmptyCommand(string[] command, Bus bus)
        {
            double distance = double.Parse(command[2]);
            
            if (bus.CanTravel(distance))
            {
                bus.Drive(distance);
                Console.WriteLine($"Bus travelled {bus.DistanceTravelled} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        private static void ExecuteDriveCommand(string[] command, Car car, Truck truck, Bus bus)
        {
            double distance = double.Parse(command[2]);

            if (command[1] == "Car")
            {
                if (car.CanTravel(distance))
                {
                    car.Drive(distance);
                    Console.WriteLine($"Car travelled {car.DistanceTravelled} km");
                }
                else
                {
                    Console.WriteLine("Car needs refueling");
                }
            }
            else if (command[1] == "Truck")
            {
                if (truck.CanTravel(distance))
                {
                    truck.Drive(distance);
                    Console.WriteLine($"Truck travelled {truck.DistanceTravelled} km");
                }
                else
                {
                    Console.WriteLine("Truck needs refueling");
                }
            }
            else if (command[1] == "Bus")
            {
                if (bus.CanTravel(distance))
                {
                    bus.DriveWithPassangers(distance);
                    Console.WriteLine($"Bus travelled {bus.DistanceTravelled} km");
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }
            }
        }

        private static void ExecuteRefuelCommand(string[] command, Car car, Truck truck, Bus bus)
        {
            if (command[1] == "Car")
            {
                car.Refuel(double.Parse(command[2]));
            }
            else if (command[1] == "Truck")
            {
                truck.Refuel(double.Parse(command[2]));
            }
            else if (command[1] == "Bus")
            {
                bus.Refuel(double.Parse(command[2]));
            }
        }
    }
}
