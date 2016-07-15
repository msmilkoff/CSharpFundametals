namespace _06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var entities = new List<IBirthable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                if (tokens[0] == "Citizen")
                {
                    entities.Add(new Citizen(tokens[1], tokens[2], tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    entities.Add(new Pet(tokens[1], tokens[2]));
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            foreach (var entity in entities)
            {
                if (entity.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(entity.BirthDate);
                }
            }
        }
    }

    public class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }
    }

    public class Citizen : ICitizen, IBirthable
    {
        public Citizen(string name, string age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Age { get; private set; }

        public string BirthDate { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }
    }

    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }
    }

    public interface IBirthable
    {
        string BirthDate { get; }
    }

    public interface IIdentifiable
    {
        string Id { get; }
    }

    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }

    public interface ICitizen : IIdentifiable
    {
        string Name { get; }

        string Age { get; }
    }
}
