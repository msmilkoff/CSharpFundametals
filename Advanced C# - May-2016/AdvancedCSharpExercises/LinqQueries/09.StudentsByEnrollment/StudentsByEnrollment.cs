namespace _09.StudentsByEnrollment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByEnrollment
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string facultyNumber = inputArgs[0];

                var grades = inputArgs
                    .Skip(1)
                    .Select(int.Parse)
                    .ToList();

                var student = new Student(facultyNumber, grades);
                students.Add(student);

                input = Console.ReadLine();
            }

            var gradesOfStudentsByEnrollment = students
                .Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
                .Select(s => s.Grades);

            foreach (var gradesList in gradesOfStudentsByEnrollment)
            {
                Console.WriteLine(string.Join(" ", gradesList));
            }
        }
    }

    public struct Student
    {
        public Student(string facultyNumber, List<int> grades)
        {
            this.FacultyNumber = facultyNumber;
            this.Grades = grades;

        }
        public string FacultyNumber { get; set; }

        public List<int> Grades { get; set; }
    }
}
