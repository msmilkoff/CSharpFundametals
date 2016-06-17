namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using Static_Data;

    public static class RepositoryFilter
    {
        public static void FilterAndTake(
            Dictionary<string, List<int>> wantedData,
            string wantedFilter,
            int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(wantedData, x => x >= 5, studentsToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
                    break;
            }
        }

        private static void FilterAndTake(
            Dictionary<string, List<int>> wantedData,
            Predicate<double> givenFilter,
            int studentsToTake)
        {
            int printedStudents = 0;
            foreach (var studentScore in wantedData)
            {
                if (printedStudents == studentsToTake)
                {
                    break;
                }

                double averageScore = studentScore.Value.Average();
                double percentageOfFulfillment = averageScore / 100;
                double mark = percentageOfFulfillment * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.DisplayStudent(studentScore);
                    printedStudents++;
                }
            }
        }
    }
}