namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;

    public class DownloadFileCommand : Command
    {
        public DownloadFileCommand(
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

            string url = this.Data[1];
            this.DownloadManager.Download(url);
        }
    }
}