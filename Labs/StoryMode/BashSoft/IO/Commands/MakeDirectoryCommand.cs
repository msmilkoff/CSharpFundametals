using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, DownloadManager downloadManager, IOManager ioManager)
            : base(input, data, judge, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException();
            }

            string folderName = this.Data[1];
            this.IOManager.CreateDirectoryInCurretFolder(folderName);
        }
    }
}