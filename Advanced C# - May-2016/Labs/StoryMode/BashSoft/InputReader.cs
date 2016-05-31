namespace BashSoft
{
    using System;

    public static class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage(SessionData.currentPath + ">");

                string input = Console.ReadLine();
                input = input.Trim();

                CommandInterpreter.InterpretCommand(input);

                if (input == EndCommand)
                {
                    break;
                }
            }
        }
    }
}