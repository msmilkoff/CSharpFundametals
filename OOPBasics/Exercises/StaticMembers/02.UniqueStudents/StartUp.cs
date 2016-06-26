namespace _02.UniqueStudents
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string studentName = Console.ReadLine();
            while (studentName != "End")
            {
                var student = new Student(studentName);
                studentName = Console.ReadLine();
            }

            Console.WriteLine(Student.GetDistinctStudentsCount());
        }
    }

    public class Student
    {
        private static HashSet<string> studentNames = new HashSet<string>();

        public Student(string name)
        {
            this.Name = name;
            studentNames.Add(name);
        }

        public string Name { get; set; }

        public static int GetDistinctStudentsCount()
        {
            return studentNames.Count;
        }
    }
}
