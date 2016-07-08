namespace BashSoft.IO.Commands
{
    using Judge;
    using Network;
    using Repository;
    using Exceptions;

    public class PrintOrderedStudentsCommand : Command
    {
        public PrintOrderedStudentsCommand(
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
            string comparison = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();


        }

        private void ParseParametersForOrderAndTake(
            string takeCommand,
            string takeQuantity,
            string courseName,
            string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, comparison, studentsToTake);
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