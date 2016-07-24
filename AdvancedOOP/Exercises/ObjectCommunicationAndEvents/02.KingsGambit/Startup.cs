namespace _02.KingsGambit
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var units = new Dictionary<string, IUnit>();

            string kingName = Console.ReadLine();
            var king = new King(kingName);
            units.Add(king.Name, king);

            var guardNames = Console.ReadLine().Split();
            foreach (var guardName in guardNames)
            {
                units.Add(guardName, new RoyalGuard(guardName));
            }

            var footmanNames = Console.ReadLine().Split();
            foreach (var footmanName in footmanNames)
            {
                units.Add(footmanName, new Footman(footmanName));
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Attack King")
                {
                    foreach (var unit in units)
                    {
                        unit.Value.RespondToAttack();
                    }
                }

                var tokens = input.Split();
                if (tokens[0] == "Kill")
                {
                    units.Remove(tokens[1]);
                }

                input = Console.ReadLine();
            }
        }
    }
}
