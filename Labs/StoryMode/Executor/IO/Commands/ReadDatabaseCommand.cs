namespace Executor.IO.Commands
{
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    public class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(string input, string[] data, Tester tester,
            StudentsRepository repository, DownloadManager downloadManager, IOManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            this.Repository.LoadData(fileName);
        }
    }
}
