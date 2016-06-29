namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ShoppingSpreeMain
    {
        public static void Main()
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            string personInfo = Console.ReadLine();
            string productInfo = Console.ReadLine();

            var regex = new Regex(@"(\w+)\s*=\s*(\d+|-\d+)");
            var personMatches = regex.Matches(personInfo);
            var productMatches = regex.Matches(productInfo);

            try
            {
                AddPeople(personMatches, people);
                AddProducts(productMatches, products);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var person = people[inputArgs[0]];
                var product = products[inputArgs[1]];
                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value);
            }
        }

        private static void AddProducts(MatchCollection productMatches, Dictionary<string, Product> products)
        {
            foreach (Match match in productMatches)
            {
                string productName = match.Groups[1].Value;
                decimal price = decimal.Parse(match.Groups[2].Value);
                products.Add(productName, new Product(productName, price));
            }
        }

        private static void AddPeople(MatchCollection personMatches, Dictionary<string, Person> people)
        {
            foreach (Match match in personMatches)
            {
                string personName = match.Groups[1].Value;
                decimal money = decimal.Parse(match.Groups[2].Value);
                people.Add(personName, new Person(personName, money));
            }
        }
    }

    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private ICollection<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }

                this.money = value;
            }
        }

        public ICollection<Product> Products => this.products;

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Price)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Products.Add(product);
            this.Money -= product.Price;
        }

        public override string ToString()
        {
            return this.Products.Count > 0
                ? $"{this.Name} - {string.Join(", ", this.Products)}"
                : $"{this.Name} - Nothing bought";
        }
    }
}
