namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public  class StudentsByAge
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine().Trim();
            while (input != "END")
            {
                string name = input.Substring(0, input.LastIndexOf(' '));
                int age = int.Parse(input.Substring(input.LastIndexOf(' ') + 1));

                var student = new Student(name, age);
                students.Add(student);

                input = Console.ReadLine().Trim();
            }

            var studentsByAge = students
                .Where(s => s.Age >= 18 && s.Age <= 24);

            foreach (var student in studentsByAge)
            {
                Console.WriteLine($"{student.Name} {student.Age}");
            }
        }
    }

    public struct Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
