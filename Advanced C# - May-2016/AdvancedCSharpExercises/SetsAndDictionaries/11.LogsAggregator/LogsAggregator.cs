namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main(string[] args)
        {
            var usersByLogs =
                new SortedDictionary<string, Tuple<SortedSet<string>, List<int>>>();

            int logsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < logsCount; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(' ');
                string user = inputArgs[1];
                string ip = inputArgs[0];
                int duration = int.Parse(inputArgs[2]);

                if (!usersByLogs.ContainsKey(user))
                {
                    usersByLogs.Add(
                        user, new Tuple<SortedSet<string>, List<int>>(
                            new SortedSet<string>(), new List<int>()));
                }

                if (!usersByLogs[user].Item1.Contains(ip))
                {
                    usersByLogs[user].Item1.Add(ip);
                }

                usersByLogs[user].Item2.Add(duration);
            }

            foreach (var userLogPair in usersByLogs)
            {
                Console.WriteLine("{0}: {1} [{2}]",
                    userLogPair.Key,
                    userLogPair.Value.Item2.Sum(),
                    string.Join(", ", userLogPair.Value.Item1));
            }
        }
    }
}
