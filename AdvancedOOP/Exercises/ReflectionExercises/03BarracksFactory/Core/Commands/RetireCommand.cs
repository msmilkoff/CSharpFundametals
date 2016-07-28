namespace _03BarracksFactory.Core.Commands
{
    using System;
    using Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            string output;
            try
            {
                this.Repository.RemoveUnit(unitType);
                output = $"{unitType} retired!";
            }
            catch (InvalidOperationException ex)
            {
                output = ex.Message;
            }

            return output;
        }
    }
}