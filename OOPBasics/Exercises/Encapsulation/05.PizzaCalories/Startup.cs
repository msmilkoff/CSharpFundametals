namespace _05.PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string firstLine = Console.ReadLine();

            if (firstLine.StartsWith("Pizza"))
            {
                try
                {
                    ExecutePizzaCommand(firstLine);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                ExecuteIngredientsCommand(firstLine);
            }
        }

        private static void ExecuteIngredientsCommand(string input)
        {
            while (input != "END")
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (data[0])
                    {
                        case "Dough":
                            var dough = CreateDough(data);
                            Console.WriteLine($"{dough.GetTotalCalories():F2}");
                            break;
                        case "Topping":
                            var topping = CreateTopping(data);
                            Console.WriteLine($"{topping.GetTotalCalories():F2}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                input = Console.ReadLine();
            }
        }

        private static void ExecutePizzaCommand(string input)
        {
            var pizza = CreatePizza(input.Split());
            while (input != "END")
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (data[0])
                    {
                        case "Dough":
                            var dough = CreateDough(data);
                            pizza.Dough = dough;
                            break;
                        case "Topping":
                            var topping = CreateTopping(data);
                            pizza.Toppings.Add(topping);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} – {pizza.GetTotalPizzaCalories():F2} Calories.");
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
