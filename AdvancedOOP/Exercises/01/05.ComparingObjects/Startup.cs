namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var people = new List<Person>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] personInfo = input.Split();
                people.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));

                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine());

            var person = people[personIndex - 1];

            int equalCount = people.Count(p => p.CompareTo(person) == 0) - 1;
            int notEqualCount = people.Count - equalCount;
            int totalPeople = people.Count;

            if (equalCount == 0)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine($"{equalCount} {notEqualCount} {totalPeople}");
        }
    }

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) >= 0)
            {
                if (this.Age.CompareTo(other.Age) >= 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
            }

            return -1;
        }
    }
}
