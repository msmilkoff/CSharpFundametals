namespace _05.PizzaCalories
{
    using System;

    public enum ToppingType
    {
        Meat,
        Veggies,
        Cheese,
        Sauce
    }

    public class Topping
    {
        private ToppingType toppingType;
        private double toppingModifier;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = this.GetToppingType(toppingType);
            this.Weight = weight;
            this.ToppingModfier = this.GetToppingModifier();
        }

        private ToppingType ToppingType
        {
            get { return this.toppingType; }
            set { this.toppingType = value; }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < Constants.MinToppingWeight || value > Constants.MaxToppingWeight)
                {
                    throw new ArgumentException(string.Format(Messages.InvalidToppingWeight, this.ToppingType));
                }

                this.weight = value;
            }
        }

        private double ToppingModfier
        {
            get { return this.toppingModifier; }
            set { this.toppingModifier = value; }
        }

        public double GetTotalCalories()
        {
            double result = (2 * this.Weight) * this.ToppingModfier;
            return result;
        }

        private ToppingType GetToppingType(string toppingType)
        {
            ToppingType result;
            bool isValidTopping = Enum.TryParse(toppingType, true, out result);
            if (!isValidTopping)
            {
                throw new ArgumentException(string.Format(Messages.InvalidToppingType, toppingType));
            }

            return result;
        }
        
        private double GetToppingModifier()
        {
            double result = double.NaN;
            switch (this.ToppingType)
            {
                case ToppingType.Meat:
                    result = Constants.MeatModifier;
                    break;
                case ToppingType.Veggies:
                    result = Constants.VeggiesModifier;
                    break;
                case ToppingType.Cheese:
                    result = Constants.CheeseModifier;
                    break;
                case ToppingType.Sauce:
                    result = Constants.SauceModifier;
                    break;
            }

            return result;
        }
    }
}