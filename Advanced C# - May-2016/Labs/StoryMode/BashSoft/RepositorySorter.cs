namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    public static class RepositorySorter
    {
        public static void OrderAndTake(
            Dictionary<string, List<int>> wantedData,
            string comparison,
            int studentToTake)
        {
            comparison = comparison.ToLower();
            if (comparison =="ascending")
            {
                OrderAndTake(wantedData, studentToTake, CompareInOrder);
            }
            else if (comparison == "descending")
            {
                OrderAndTake(wantedData, studentToTake, ComprareDescendingOrder);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void OrderAndTake(
            Dictionary<string, List<int>> wantedData,
            int studentToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            var sortedStudents = GetStudentsSorted(wantedData, studentToTake, comparisonFunc);

            foreach (var student in sortedStudents)
            {
                OutputWriter.DisplayStudent(student);
            }
        }

        private static int CompareInOrder(
            KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = 0, totalOfSecondMarks = 0;

            foreach (var mark in firstValue.Value)
            {
                totalOfFirstMarks += mark;
            }

            foreach (var mark in secondValue.Value)
            {
                totalOfSecondMarks += mark;
            }

            return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        }

        private static int ComprareDescendingOrder(
            KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = 0, totalOfSecondMarks = 0;

            foreach (var mark in firstValue.Value)
            {
                totalOfFirstMarks += mark;
            }

            foreach (var mark in secondValue.Value)
            {
                totalOfSecondMarks += mark;
            }

            return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        }

        private static Dictionary<string, List<int>> GetStudentsSorted(
            Dictionary<string, List<int>> wantedData,
            int studentToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            int valuesTaken = 0;
            var studentsSorted = new Dictionary<string, List<int>>();
            var nextInOrder = new KeyValuePair<string, List<int>>();

            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                foreach (var student in wantedData)
                {
                    if (!string.IsNullOrEmpty(nextInOrder.Key))
                    {
                        int comparisonResult = comparisonFunc(student, nextInOrder);
                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(student.Key))
                        {
                            nextInOrder = student;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(student.Key))
                        {
                            nextInOrder = student;
                            isSorted = false;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    valuesTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
            }

            return studentsSorted;
        }
    }
}