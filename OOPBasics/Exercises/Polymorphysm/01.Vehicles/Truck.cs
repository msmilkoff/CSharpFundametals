namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAcConsumption = 1.6;
        private const double RefuelFactor = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.AcFuelConsumption = TruckAcConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + this.AcFuelConsumption;

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * RefuelFactor);
        }

        public override double FuelQuantity { get; protected set; }
    }
}