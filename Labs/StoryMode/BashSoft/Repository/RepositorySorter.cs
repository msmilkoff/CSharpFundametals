namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using Static_Data;

    public class RepositorySorter
    {
        public void OrderAndTake(
            Dictionary<string, double> wantedData,
            string comparison,
            int studentToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(wantedData
                    .OrderBy(x => x.Value)
                    .Take(studentToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(wantedData
                    .OrderByDescending(x => x.Value)
                    .Take(studentToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> wantedData)
        {
            foreach (var student in wantedData)
            {
                OutputWriter.DisplayStudent(student);
            }
        }
    }
}