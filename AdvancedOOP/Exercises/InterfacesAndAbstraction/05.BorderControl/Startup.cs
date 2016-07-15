namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var inhabitans = new List<IIdentifiable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                if (tokens.Length == 2)
                {
                    var robot = new Robot(tokens[0], tokens[1]);
                    inhabitans.Add(robot);
                }
                else if (tokens.Length == 3)
                {
                    var citizen = new Citizen(tokens[0], tokens[1], tokens[2]);
                    inhabitans.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string fakeIdSuffix = Console.ReadLine();
            foreach (var inhabitant in inhabitans)
            {
                if (inhabitant.Id.EndsWith(fakeIdSuffix))
                {
                    Console.WriteLine(inhabitant.Id);
                }
            }
        }
    }

    public class Citizen : ICitizen
    {
        public Citizen(string name, string age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Age { get; private set; }

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
