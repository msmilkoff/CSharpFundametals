namespace _06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static Dictionary<string, Team> teams = new Dictionary<string, Team>();

        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(';');
                string command = data[0];
                try
                {
                    ProcessCommand(command, data);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static void ProcessCommand(string command, string[] data)
        {
            switch (command)
            {
                case "Team":
                    CreateTeam(data);
                    break;
                case "Add":
                    AddPlayerToTeam(data);
                    break;
                case "Remove":
                    RemovePlayerFromTeam(data);
                    break;
                case "Rating":
                    ShowRating(data);
                    break;
            }
        }

        private static void ShowRating(string[] data)
        {
            if (!teams.ContainsKey(data[1]))
            {
                throw new InvalidOperationException($"Team {data[1]} does not exist.");
            }
            
            Console.WriteLine($"{teams[data[1]].Name} - {teams[data[1]].GetRating()}");
        }

        private static void RemovePlayerFromTeam(string[] data)
        {
            if (!teams.ContainsKey(data[1]))
            {
                throw new InvalidOperationException($"Team {data[1]} does not exist.");
            }

            teams[data[1]].RemovePlayer(data[2]);
        }

        private static void AddPlayerToTeam(string[] data)
        {
            if (!teams.ContainsKey(data[1]))
            {
                throw new InvalidOperationException($"Team {data[1]} does not exist.");
            }

            var player = new Player(
                data[2],
                int.Parse(data[3]),
                int.Parse(data[4]),
                int.Parse(data[5]),
                int.Parse(data[6]),
                int.Parse(data[7]));

            teams[data[1]].AddPlayer(player);
        }

        private static void CreateTeam(string[] data)
        {
            var team = new Team(data[1]);
            teams.Add(team.Name, team);
        }
    }
}
