namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                string name = input[0] + " " + input[1];
                int group = int.Parse(input[2]);

                var person  = new Person(name, group);
                people.Add(person);

                input = Console.ReadLine().Split();
            }

            var groupedPeople = people
                .GroupBy(p => p.Group)
                .OrderBy(p => p.Key)
                .ToDictionary(g => g.Key);

            foreach (var group in groupedPeople)
            {
                var names = group
                    .Value
                    .Select(g => g.Name);

                Console.WriteLine($"{group.Key} - {string.Join(", ", names)}");
            }
        }
    }

    public class Person
    {
        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }

        public int Group { get; set; }
    }
}
