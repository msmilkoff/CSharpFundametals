namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UserLogs
    {
        public static void Main(string[] args)
        {
            var messagesByUser = new SortedDictionary<string, Dictionary<string, int>>();

            const string pattern = @"IP=(.*?)message=.+? user=(\w+)";

            string command = Console.ReadLine();
            while (command != "end")
            {
                var match = Regex.Match(command, pattern);
                string user = match.Groups[2].Value;
                string ipAdress = match.Groups[1].Value;

                if (!messagesByUser.ContainsKey(user))
                {
                    messagesByUser.Add(user, new Dictionary<string, int>());
                }

                if (!messagesByUser[user].ContainsKey(ipAdress))
                {
                    messagesByUser[user].Add(ipAdress, 1);
                }
                else
                {
                    messagesByUser[user][ipAdress]++;
                }

                command = Console.ReadLine();
            }

            foreach (var outerPair in messagesByUser)
            {
                var output = new List<string>();

                Console.WriteLine($"{outerPair.Key}:");
                foreach (var innerPair in messagesByUser[outerPair.Key])
                {
                    string line = $"{innerPair.Key}=> {innerPair.Value}";
                    output.Add(line);
                }

                Console.Write(string.Join(", ", output));
                Console.WriteLine(".");
            }
        }
    }
}
