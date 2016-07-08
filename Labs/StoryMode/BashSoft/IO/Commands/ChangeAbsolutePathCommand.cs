namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;

    public class ChangeAbsolutePathCommand : Command
    {
        public ChangeAbsolutePathCommand(
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
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException();
            }

            string absolutePath = this.Data[1];
            this.IOManager.ChangeCurentDirectoryAbsolute(absolutePath);
        }
    }
}