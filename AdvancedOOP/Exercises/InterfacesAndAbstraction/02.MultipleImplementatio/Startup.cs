namespace _02.MultipleImplementation
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            PropertyInfo[] properties = identifiableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            properties = birthableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

        }
    }

    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }

        public string Id { get; private set; }
    }

    public interface IPerson
    {
        string Name { get; }

        int Age { get; }
    }

    public interface IIdentifiable
    {
        string Id { get; }
    }

    public interface IBirthable
    {
        string BirthDate { get; }
    }
}
