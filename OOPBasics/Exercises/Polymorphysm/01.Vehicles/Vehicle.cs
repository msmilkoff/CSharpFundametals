namespace _01.Vehicles
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                else if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumptionPerKm { get; protected set; }

        public virtual double TankCapacity { get; protected set; }

        public virtual double DistanceTravelled { get; protected set; }

        protected virtual double AcFuelConsumption { get; set; }

        public virtual void Drive(double distance)
        {
            if (this.CanTravel(distance))
            {
                this.DistanceTravelled = distance;
                double usedFuel = distance * this.FuelConsumptionPerKm;
                this.FuelQuantity -= usedFuel;
            }
        }
        public virtual bool CanTravel(double distance)
        {
            double maxPossibleDistance = this.FuelQuantity / this.FuelConsumptionPerKm;
            if (maxPossibleDistance >= distance)
            {
                return true;
            }

            return false;
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }
    }
}