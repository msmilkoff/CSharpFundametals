namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAcConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public void DriveWithPassangers(double distance)
        {
            this.FuelConsumptionPerKm = base.FuelConsumptionPerKm + BusAcConsumption;
            base.Drive(distance);
        }

        public override void Drive(double distance)
        {
            this.FuelConsumptionPerKm = base.FuelConsumptionPerKm;
            base.Drive(distance);
        }
    }
}