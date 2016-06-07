namespace BashSoft
{
    using System;
    using System.Collections.Generic;

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
                    FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, AverageFilter, studentsToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, PoorFilter, studentsToTake);
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

                double averageMark = Average(studentScore.Value);
                if (givenFilter(averageMark))
                {
                    OutputWriter.DisplayStudent(studentScore);
                    printedStudents++;
                }
            }
        }

        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }

        private static bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }

        private static bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }

        private static double Average(List<int> scores)
        {
            int totalScore = 0;
            foreach (var score in scores)
            {
                totalScore += score;
            }

            double percentageOfAll = totalScore / (scores.Count * 100.0);
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}