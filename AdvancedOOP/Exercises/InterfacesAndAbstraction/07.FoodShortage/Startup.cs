namespace _07.FoodShortage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var people = new Dictionary<string, IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    people.Add(tokens[0], new Citizen(tokens[0], tokens[1], tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    people.Add(tokens[0], new Rebel(tokens[0], tokens[1], tokens[2]));
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string name = input;

                if (people.ContainsKey(name))
                {
                    people[name].BuyFood();
                }

                input = Console.ReadLine();
            }

            int foodPurchased = people.Sum(p => p.Value.Food);
            Console.WriteLine(foodPurchased);
        }
    }

    public class Rebel : IBuyer
    {
        private int food;

        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public int Food
        {
            get { return this.food; }
            private set { this.food = value; }
        }

        public string Group { get; private set; }

        public void BuyFood()
        {
            this.food += 5;
        }
    }

    public class Citizen : ICitizen, IBirthable, IBuyer
    {
        private int food;

        public Citizen(string name, string age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Age { get; private set; }

        public string BirthDate { get; private set; }

        public int Food
        {
            get { return this.food; }
            private set { this.food = value; }
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public void BuyFood()
        {
            this.food += 10;
        }
    }

    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }

    public interface IBirthable
    {
        string BirthDate { get; }
    }

    public interface IIdentifiable
    {
        string Id { get; }
    }

    public interface ICitizen : IIdentifiable
    {
        string Name { get; }

        string Age { get; }
    }
}
