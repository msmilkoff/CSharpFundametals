namespace Executor.IO.Commands
{
    using System.Diagnostics;
    using Exceptions;
    using Judge;
    using Network;
    using Repository;
    using Static_data;

    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester tester, StudentsRepository repository,
                                                            DownloadManager downloadManager, IOManager ioManager)
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
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
