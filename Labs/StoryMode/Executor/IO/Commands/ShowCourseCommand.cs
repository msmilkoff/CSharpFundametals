namespace Executor.IO.Commands
{
    using Exceptions;
    using Judge;
    using Network;
    using Repository;

    public class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, Tester tester,
            StudentsRepository repository, DownloadManager downloadManager, IOManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
