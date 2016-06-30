namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using IO;
    using Static_Data;

    public class RepositoryFilter
    {
        public void FilterAndTake(
            Dictionary<string, double> studentsWithMarks,
            string wantedFilter,
            int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    this.FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
                    break;
                case "average":
                    this.FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
                    break;
                case "poor":
                    this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(
            Dictionary<string, double> studentsWithMarks,
            Predicate<double> givenFilter,
            int studentsToTake)
        {
            int printedStudents = 0;
            foreach (var studentScore in studentsWithMarks)
            {
                if (printedStudents == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentScore.Value))
                {
                    OutputWriter.DisplayStudent(new KeyValuePair<string, double>(studentScore.Key, studentScore.Value));
                    printedStudents++;
                }
            }
        }
    }
}