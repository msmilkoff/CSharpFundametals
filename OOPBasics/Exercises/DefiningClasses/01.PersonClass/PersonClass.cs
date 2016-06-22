namespace _01.PersonClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonClass
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var inputParams = input.Split();
                string name = inputParams[0];
                int age = int.Parse(inputParams[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            var sortedPeople = people
                .Where(p => p.age > 30)
                .OrderBy(p => p.name);

            Console.WriteLine(string.Join("\n", sortedPeople));
        }
    }

    public class Person
    {
        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string name;
        public int age;

        public override string ToString()
        {
            string result = $"{this.name} - {this.age}";
            return result;
        }
    }
}