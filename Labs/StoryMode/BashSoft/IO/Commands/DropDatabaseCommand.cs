namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            DownloadManager downloadManager,
            IOManager ioManager)
            : base(input, data, judge, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException();
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}