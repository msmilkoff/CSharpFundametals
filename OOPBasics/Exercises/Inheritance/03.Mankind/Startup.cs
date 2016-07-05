namespace _03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            try
            {
                var studentTokens = input?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var student = CreateStudent(studentTokens);

                input = Console.ReadLine();
                var workerTokens = input?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var worker = CreateWorker(workerTokens);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Worker CreateWorker(string[] tokens)
        {
            string firstName = tokens[0];
            string lastName = tokens[1];
            decimal weekSalary = decimal.Parse(tokens[2]);
            double workHoursPerDay = double.Parse(tokens[3]);
            var worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);

            return worker;
        }

        private static Student CreateStudent(string[] tokens)
        {
            string firstName = tokens[0];
            string lastName = tokens[1];
            string facultyNumber = tokens[2];
            var student = new Student(firstName, lastName, facultyNumber);

            return student;
        }
    }
}
