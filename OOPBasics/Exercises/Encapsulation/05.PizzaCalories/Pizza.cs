namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private ICollection<Topping> toppings;
        private Dough dough;

        public Pizza(string name, int toppingsCount)
        {
            this.Name = name;
            this.toppings = this.InitToppings(toppingsCount);
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > Constants.MaxPizzaLength)
                {
                    throw new ArgumentException(Messages.InvalidPizzaName);
                }

                this.name = value;
            }
        }

        public ICollection<Topping> Toppings
        {
            get { return this.toppings; }
            set { this.toppings = value; }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public double GetTotalPizzaCalories()
        {
            double toppingsCalories = this.Toppings.Sum(t => t.GetTotalCalories());
            double doughCalories = this.Dough.GetTotalCalories();
            double totalPizzaCalories = toppingsCalories + doughCalories;

            return totalPizzaCalories;
        }

        private ICollection<Topping> InitToppings(int toppingsCount)
        {
            if (toppingsCount > Constants.MaxAmountOfToppings)
            {
                throw new ArgumentException(Messages.InvalidAmountOfToppings);
            }

            return new List<Topping>();
        }

        public override string ToString()
        {
            double calories = this.GetTotalPizzaCalories();
            string output = $"{this.Name} - {calories:F2} Calories.";

            return output;
        }
    }
}