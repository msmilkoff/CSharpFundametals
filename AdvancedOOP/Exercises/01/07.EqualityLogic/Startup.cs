namespace _07.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var comparer = new PesonComparator();;

            var treeSet = new SortedSet<Person>(comparer);
            var hashSet = new HashSet<Person>();

            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                treeSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(treeSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }

    public class PesonComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
            {
                return x.Age.CompareTo(y.Age);
            }

            return x.Name.CompareTo(y.Name);
        }
    }

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                if (this.Age.CompareTo(other.Age) == 0)
                {
                    return 0;
                }
            }

            return -1;
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            if (this.Name.CompareTo(other.Name) == 0)
            {
                if (this.Age.CompareTo(other.Age) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool Equals(Person other)
        {
            return string.Equals(this.Name, other.Name) && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
