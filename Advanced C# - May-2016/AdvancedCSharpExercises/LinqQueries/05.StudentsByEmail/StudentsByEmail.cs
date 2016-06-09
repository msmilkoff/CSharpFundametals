namespace _05.StudentsByEmail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByEmail
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string firstName = inputArgs[0] +  " " + inputArgs[1];
                string lastName = inputArgs[2];

                var student = new Student(firstName, lastName);
                students.Add(student);

                input = Console.ReadLine();
            }

            string result = string.Join("\n", students
                .Where(s => s.Email.Contains("gmail"))
                .Select(s => s.Name));

            Console.WriteLine(result);
        }
    }

    public struct Student
    {
        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
