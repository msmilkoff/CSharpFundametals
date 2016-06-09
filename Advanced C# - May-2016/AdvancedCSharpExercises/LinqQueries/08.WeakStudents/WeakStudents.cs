namespace _08.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0] + " " + inputArgs[1];

                var grades = inputArgs
                    .Skip(2)
                    .Select(int.Parse)
                    .ToList();

                var student = new Student(name, grades);
                students.Add(student);

                input = Console.ReadLine();
            }

            var weakStudents = students
                .Where(s => s.Grades.Count(g => g <= 3) >= 2)
                .Select(s => s.Name);

            Console.WriteLine(string.Join("\n", weakStudents));
        }
    }

    public struct Student
    {
        public Student(string name, List<int> grades)
        {
            this.Name = name;
            this.Grades = grades;
        }

        public string Name { get; set; }

        public List<int> Grades { get; set; }
    }
}
