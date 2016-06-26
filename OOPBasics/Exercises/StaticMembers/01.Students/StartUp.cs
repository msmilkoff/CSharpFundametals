namespace _01.Students
{
    using System;

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

            Console.WriteLine(Student.GetStudentsCount());
        }
    }

    public class Student
    {
        private static int studentsCount = 5;

        public Student(string name)
        {
            this.Name = name;
            studentsCount++;
        }

        public string Name { get; set; }

        public static int GetStudentsCount()
        {
            return studentsCount;
        }
    }
}
