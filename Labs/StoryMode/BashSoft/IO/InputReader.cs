namespace BashSoft.IO
{
    using System;
    using Static_Data;

    public class InputReader
    {
        private const string EndCommand = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage(SessionData.currentPath + ">");

                string input = Console.ReadLine();
                input = input.Trim();

                this.interpreter.InterpretCommand(input);

                if (input == EndCommand)
                {
                    break;
                }
            }
        }
    }
}