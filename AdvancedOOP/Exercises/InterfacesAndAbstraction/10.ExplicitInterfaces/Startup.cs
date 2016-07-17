namespace _10.ExplicitInterfaces
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                var citizen = new Citizen(tokens[0], tokens[1], tokens[2]);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }

    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private string age;

        public Citizen(string name, string country, string age)
        {
            this.name = name;
            this.country = country;
            this.age = age;
        }

        string IResident.Name => this.name;

        public string Age => this.age;

        public string Country => this.country;


        string IPerson.GetName()
        {
            return this.name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.name}";
        }

        string IPerson.Name => this.name;
    }

    public interface IPerson
    {
        string Name { get; }

        string Age { get; }

        string GetName();
    }

    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
