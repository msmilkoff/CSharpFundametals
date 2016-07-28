namespace _03BarracksFactory.Core.Commands
{
    using System;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CurrentNamespace = "_03BarracksFactory.Core.Commands.";
        private const string CommandSuffix = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            IExecutable result = null;
            string commandTypeName = CurrentNamespace + commandName + CommandSuffix;
            var commandType = Type.GetType(commandTypeName, true, true);

            var parameters = new object[]
                {
                    data, this.repository, this.unitFactory
                };

            var command = Activator.CreateInstance(commandType, parameters);


            result = command as IExecutable;
            return result;
        }
    }
}