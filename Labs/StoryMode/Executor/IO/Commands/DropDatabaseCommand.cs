namespace Executor.IO.Commands
{
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester tester, StudentsRepository repository, DownloadManager downloadManager, IOManager ioManager) : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
