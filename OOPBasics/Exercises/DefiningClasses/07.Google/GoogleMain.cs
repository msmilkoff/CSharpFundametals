namespace _07.Google
{
    using System;
    using System.Collections.Generic;

    public class GoogleMain
    {
        public static void Main()
        {
            var people = new Dictionary<string, Person>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var personInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string personName = personInfo[0];
                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, new Person(personName));
                }

                switch (personInfo[1])
                {
                    case "company":
                        string companyName = personInfo[2];
                        string department = personInfo[3];
                        decimal salary = decimal.Parse(personInfo[4]);
                        people[personName].Company = new Company(companyName, department, salary);
                        break;
                    case "pokemon":
                        string pokemonName = personInfo[2];
                        string pokemonType = personInfo[3];
                        people[personName].Pokemon.Add(new Pokemon(pokemonName, pokemonType));
                        break;
                    case "parents":
                        string parentName = personInfo[2];
                        string parentBirthDay = personInfo[3];
                        people[personName].Parents.Add(new Parent(parentName, parentBirthDay));
                        break;
                    case "children":
                        string childName = personInfo[2];
                        string childBirthDay = personInfo[3];
                        people[personName].Children.Add(new Child(childName, childBirthDay));
                        break;
                    case "car":
                        string model = personInfo[2];
                        double speed = double.Parse(personInfo[3]);
                        people[personName].Car = new Car(model, speed);
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            string personToPrint = Console.ReadLine();
            Console.WriteLine(people[personToPrint]);
        }
    }
}