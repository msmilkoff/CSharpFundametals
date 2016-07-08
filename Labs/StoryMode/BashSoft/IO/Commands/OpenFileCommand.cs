namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;
    using System.Diagnostics;
    using Static_Data;

    public class OpenFileCommand : Command
    {
        public OpenFileCommand
            (string input,
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

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "//" + fileName);
        }
    }
}