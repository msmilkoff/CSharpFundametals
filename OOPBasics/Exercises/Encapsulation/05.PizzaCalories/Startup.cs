namespace _05.PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main()  // TODO: Catch exceptions and add toppings to pizza.
        {
            string[] pizzaInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] doughInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var pizza = CreatePizza(pizzaInfo);
            var dough = CreateDough(doughInfo);

            int toppingCount = int.Parse(pizzaInfo[2]);
            for (int i = 0; i < toppingCount; i++)
            {
                string[] toppingInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static Pizza CreatePizza(string[] data)
        {
            string name = data[1];
            int toppingsCount = int.Parse(data[2]);

            var pizza = new Pizza(name, toppingsCount);

            return pizza;
        }

        private static Topping CreateTopping(string[] data)
        {
            string toppingType = data[1];
            double toppingWeight = double.Parse(data[2]);

            var topping = new Topping(toppingType, toppingWeight);

            return topping;
        }

        private static Dough CreateDough(string[] data)
        {
            string flourType = data[1];
            string bakingTechnique = data[2];
            double doughWeight = double.Parse(data[3]);

            var dough = new Dough(flourType, bakingTechnique, doughWeight);

            return dough;
        }
    }
}
