namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine().Trim();
            while (input !=  "END")
            {
                string name = input.Substring(0, input.LastIndexOf(' '));
                int group = int.Parse(input.Substring(input.LastIndexOf(' ') + 1));

                var student = new Student(name, group);
                students.Add(student);

                input = Console.ReadLine().Trim();
            }

            var studentsByGroup = students
                .Where(s => s.Group == 2)
                .OrderBy(s => s.Name);

            foreach (var student in studentsByGroup)
            {
                Console.WriteLine(student.Name);
            }
        }
    }

    public struct Student
    {
        public Student(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }

        public int Group { get; set; }
    }
}
