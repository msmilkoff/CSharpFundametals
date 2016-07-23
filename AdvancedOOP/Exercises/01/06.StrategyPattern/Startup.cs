namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Startup
    {
        public static void Main()
        {
            var nameComparer = new NameComparator();
            var ageComparer = new AgeComparer();

            var peopleByName = new SortedSet<Person>(nameComparer);
            var peopleByAge = new SortedSet<Person>(ageComparer);

            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                var person  = new Person(tokens[0], int.Parse(tokens[1]));

                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            foreach (var person in peopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleByAge)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }


    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length == y.Name.Length)
            {
                return string.Compare(x.Name[0].ToString(), y.Name[0].ToString(), true, CultureInfo.CurrentCulture);
            }

            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
