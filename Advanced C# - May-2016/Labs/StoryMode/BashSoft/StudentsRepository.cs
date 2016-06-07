namespace BashSoft
{
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");

                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedMessage);
            }
        }


        public static void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.DisplayStudent(
                    new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.DisplayStudent(studentMarksEntry);
                }
            }
        }

        private static void ReadData(string fileName)
        {
            string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            var regex = new Regex(pattern);
            string[] allInputLines = File.ReadAllLines(fileName);

            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]) && regex.IsMatch(allInputLines[line]))
                {
                    var currentMatch = regex.Match(allInputLines[line]);
                    string courseName = currentMatch.Groups[1].Value;
                    string username = currentMatch.Groups[2].Value;
                    int studetScoreOnTask;
                    bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studetScoreOnTask);

                    if (hasParsedScore && studetScoreOnTask >= 0 && studetScoreOnTask <= 100)
                    {
                        if (!studentsByCourse.ContainsKey(courseName))
                        {
                            studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                        }

                        if (!studentsByCourse[courseName].ContainsKey(username))
                        {
                            studentsByCourse[courseName].Add(username, new List<int>());
                        }

                        studentsByCourse[courseName][username].Add(studetScoreOnTask);
                    }
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidCommand);
                }
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("StudentsRepository read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedMessage);
            }

            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilter.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorter.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}
