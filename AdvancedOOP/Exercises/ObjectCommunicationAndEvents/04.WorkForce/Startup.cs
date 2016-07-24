namespace _04.WorkForce
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var employees = new Dictionary<string, IEmployee>();
            var jobs = new Dictionary<string, Job>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                switch (tokens[0])
                {
                    case "StandartEmployee":
                        employees.Add(tokens[1], new StandartEmployee(tokens[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(tokens[1], new PartTimeEmployee(tokens[1]));
                        break;
                    case "Job":
                        jobs.Add(tokens[1], new Job(tokens[1], int.Parse(tokens[2]), employees[tokens[3]]));
                        break;
                    case "Pass":
                        foreach (var job in jobs)
                        {
                            if (!job.Value.IsJobDone)
                            {
                                job.Value.Update();
                            }
                        }
                        break;
                    case "Status":
                        foreach (var job in jobs)
                        {
                            if (!job.Value.IsJobDone)
                            {
                                Console.WriteLine(job.Value);
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
