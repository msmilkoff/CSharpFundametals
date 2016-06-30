namespace BashSoft.Models
{
    using System.Collections.Generic;
    using Exceptions;

    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidFileNameException(InvalidStringException.NullOrEmptyValue);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName => this.studentsByName;

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                 throw new DuplicateEntryInStructureException(
                     string.Format(student.UserName, this.name));
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}