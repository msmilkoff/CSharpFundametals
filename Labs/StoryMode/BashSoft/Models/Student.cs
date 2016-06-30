namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Static_Data;

    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException(nameof(this.userName));
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(
                    string.Format(this.userName, course.Name));
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new KeyNotFoundException(ExceptionMessages.NotEnrolledInCourse);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask;

            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}