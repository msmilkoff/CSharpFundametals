namespace _12.PrintPeople
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var people = new SortedSet<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                var personInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string occupation = personInfo[2];
                people.Add(new Person(name, age, occupation));

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string occupation)
        {
            this.Name = name;
            this.Age = age;
            this.Occupation = occupation;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Age >= other.Age)
            {
                return 1;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"{this.Name} - age: {this.Age}, occupation: {this.Occupation}";
        }
    }
}
