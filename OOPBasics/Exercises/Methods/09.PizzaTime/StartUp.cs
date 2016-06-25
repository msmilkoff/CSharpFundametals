namespace _09.PizzaTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            var pizzas = new List<Pizza>();

            string input = Console.ReadLine();

            var regex = new Regex(@"(\d+)(\w+)");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                int group = int.Parse(match.Groups[1].Value);
                string name = match.Groups[2].Value;

                pizzas.Add(new Pizza(group, name));
            }

            var pizzasToPrint = Pizza.GetPizzasByGroups();

            foreach (var pizza in pizzasToPrint)
            {
                Console.WriteLine($"{pizza.Key} - {string.Join(", ", pizza.Value)}");
            }
        }
    }

    public class Pizza
    {
        private static readonly SortedDictionary<int, List<string>> pizzasByGroup =
            new SortedDictionary<int, List<string>>();

        public Pizza(int group, string name)
        {
            this.Group = group;
            this.Name = name;
            AddPizza(group, name);
        }

        public int Group { get; set; }

        public string Name { get; set; }

        public List<string> PizzaNames { get; set; }

        public static SortedDictionary<int, List<string>> GetPizzasByGroups(params int[] groups)
        {
            // if no groups are specified - return all pizzas.
            if (groups.Length == 0)
            {
                return pizzasByGroup;
            }

            var selectedPizzas = new SortedDictionary<int, List<string>>();
            foreach (var group in groups)
            {
                if (!selectedPizzas.ContainsKey(group))
                {
                    selectedPizzas.Add(group, pizzasByGroup[group]);
                }
            }

            return selectedPizzas;
        }

        private static void AddPizza(int group, string name)
        {
            if (!pizzasByGroup.ContainsKey(group))
            {
                pizzasByGroup.Add(group, new List<string>());
            }

            pizzasByGroup[group].Add(name);
        }
    }
}
