namespace _07_09.CustomListProblems
{
    using System;

    public class CommandInterpeter
    {
        public void InterpretCommand(string[] command, CustomList<string> list)
        {
            switch (command[0])
            {
                case "Add":
                    list.Add(command[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(command[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(command[1]));
                    break;
                case "Swap":
                    list.Swap(int.Parse(command[1]), int.Parse(command[2]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(command[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
                case "END":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}