namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using IO;
    using Static_Data;

    public class StudentsRepository
    {
        private bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");

                this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                this.ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedMessage);
            }
        }

        public void UnloadData()
        {
            if (this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedMessage);
            }

            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInitialized = false;
        }

        public void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (this.IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.DisplayStudent(
                    new KeyValuePair<string, List<int>>(userName, this.studentsByCourse[courseName][userName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentMarksEntry in this.studentsByCourse[courseName])
                {
                    OutputWriter.DisplayStudent(studentMarksEntry);
                }
            }
        }

        private void ReadData(string fileName)
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
                        if (!this.studentsByCourse.ContainsKey(courseName))
                        {
                            this.studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                        }

                        if (!this.studentsByCourse[courseName].ContainsKey(username))
                        {
                            this.studentsByCourse[courseName].Add(username, new List<int>());
                        }

                        this.studentsByCourse[courseName][username].Add(studetScoreOnTask);
                    }
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidCommand);
                }
            }

            this.isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("StudentsRepository read!");
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (this.isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedMessage);
            }

            if (this.studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.studentsByCourse[courseName].Count;
                }

                this.filter.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                this.sorter.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}
