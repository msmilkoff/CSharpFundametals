namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAcConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.AcFuelConsumption = CarAcConsumption;
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + this.AcFuelConsumption;
    }
}