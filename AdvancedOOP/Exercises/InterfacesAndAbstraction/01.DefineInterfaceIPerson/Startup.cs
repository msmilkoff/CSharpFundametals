namespace _01.DefineInterfaceIPerson
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            Type personInterface = typeof(Citizen).GetInterface("IPerson");
            PropertyInfo[] properties = personInterface.GetProperties();
            Console.WriteLine(properties.Length);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }

    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }
    }

    public interface IPerson
    {
        string Name { get; }

        int Age { get; }
    }
}
