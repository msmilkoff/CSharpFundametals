namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;

    public class PrintFilteredStudentsCommand : Command
    {
        public PrintFilteredStudentsCommand(
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
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException();
            }

            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();


        }

        private void ParseParametersForFilterAndTake(
            string takeCommand,
            string takeQuantity,
            string courseName,
            string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentToTake);
                    if (hasParsed)
                    {
                        this.Repository.FilterAndTake(courseName, filter, studentToTake);
                    }
                    else
                    {
                        throw new InvalidCommandException();
                    }
                }
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}