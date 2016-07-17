namespace _07_09.CustomListProblems
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var list = new CustomList<string>();
            var interpeter = new CommandInterpeter();

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                interpeter.InterpretCommand(command, list);
            }
        }
    }
}
