namespace Executor.IO.Commands
{
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester tester,
            StudentsRepository repository, DownloadManager downloadManager, IOManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.Tester.CompareContent(firstPath, secondPath);
        }
    }
}
