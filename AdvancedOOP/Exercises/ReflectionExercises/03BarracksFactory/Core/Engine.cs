namespace _03BarracksFactory.Core
{
    using System;
    using Commands;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandInterpreter = new CommandInterpreter(repository, unitFactory);
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    var command = this.commandInterpreter.InterpretCommand(data, commandName);
                    string result = command.Execute();
                    if (result == null)
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
