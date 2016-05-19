namespace _06.MinersTask
{
    using System;
    using System.Collections.Generic;

    public class MinersTask
    {
        public static void Main(string[] args)
        {
            var resourses = new Dictionary<string, int>();

            var input = Console.ReadLine();
            while (true)
            {
                if (input == "stop")
                {
                    break;
                }
                    int amount = int.Parse(Console.ReadLine());

                    if (!resourses.ContainsKey(input))
                    {
                        resourses.Add(input, amount);
                    }
                    else
                    {
                        resourses[input] += amount;
                    }

                input = Console.ReadLine();
            }

            foreach (var resourse in resourses)
            {
                Console.WriteLine($"{resourse.Key} -> {resourse.Value}");
            }
        }
    }
}
