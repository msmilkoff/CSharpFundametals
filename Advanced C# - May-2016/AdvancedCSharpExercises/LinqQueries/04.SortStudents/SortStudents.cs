namespace _04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string firstName = inputArgs[0];
                string lastName = inputArgs[1];

                var student = new Student(firstName, lastName);
                students.Add(student);

                input = Console.ReadLine();
            }

            var sortedStudents = students
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }

    public struct Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
