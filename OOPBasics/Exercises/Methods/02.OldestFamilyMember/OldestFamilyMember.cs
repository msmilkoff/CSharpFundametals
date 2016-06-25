namespace _02.OldestFamilyMember
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    public class OldestFamilyMember
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }


            var family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string personName = personInfo[0];
                int personAge = int.Parse(personInfo[1]);
                var person = new Person(personName, personAge);

                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.name} {oldest.age}");
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string name;
        public int age;
    }

    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestAge = this.People.Max(p => p.age);

            var oldestPerson = this.People.First(x => x.age == oldestAge);
            return oldestPerson;
        }
    }
}
