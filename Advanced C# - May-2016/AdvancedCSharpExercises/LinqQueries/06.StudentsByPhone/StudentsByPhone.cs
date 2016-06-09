namespace _06.StudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByPhone
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string name = inputArgs[0] + " " + inputArgs[1];
                string phone = inputArgs[2];

                var student = new Student(name, phone);
                students.Add(student);

                input = Console.ReadLine();
            }

            var studentsByPhone = students
                .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
                .Select(s => s.Name);

            Console.WriteLine(string.Join("\n", studentsByPhone));
        }
    }

    public struct Student
    {
        public Student(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
