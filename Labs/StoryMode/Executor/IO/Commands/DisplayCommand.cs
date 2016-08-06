namespace Executor.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class DisplayCommand : Command
    {
        public DisplayCommand(
            string input,
            string[] data,
            IContentComparer tester,
            IDatabase repository,
            IDownloadManager downloadManager,
            IDirectoryManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            var data = this.Data;
            if (data.Length != 3)
            {
                throw new InvalidCastException(this.Input);
            }

            string entityToDisplay = data[1];
            string sortType = data[2];
            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                var comparer = this.CreateStudentComparer(sortType);
                var list = this.Repository.GetAllStudentsSorted(comparer);

                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                var comparer = this.CreateCourseComparer(sortType);
                var list = this.Repository.GetAllCoursesSorted(comparer);

                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
        }

        private IComparer<ICourse> CreateCourseComparer(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((x, y) => x.CompareTo(y));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((x, y) => x.CompareTo(y));
            }
            else
            {
                throw new InvalidOperationException(this.Input);
            }
        }

        private IComparer<IStudent> CreateStudentComparer(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((x, y) => x.CompareTo(y));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((x, y) => x.CompareTo(y));
            }
            else
            {
                throw new InvalidOperationException(this.Input);
            }
        }
    }
}