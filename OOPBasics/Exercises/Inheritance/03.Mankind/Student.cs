namespace _03.Mankind
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private const int MinFirstNameLength = 4;
        private const int MinLastNameLength = 3;
        private const int MinFacultyNumberLength = 5;
        private const int MaxFacultyNumberLength = 10;

        private readonly string facultyNumberPattern =
            $"^[a-zA-Z0-9]{{{MinFacultyNumberLength},{MaxFacultyNumberLength}}}$";

        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public override string FirstName
        {
            get { return base.FirstName; }
            protected set
            {
                ValidateStudentName(value, MinFirstNameLength, "firstName");
                base.FirstName = value;
            }
        }

        public override string LastName
        {
            get { return base.LastName; }
            protected set
            {
                ValidateStudentName(value, MinLastNameLength, "lastName");
                base.LastName = value;
            }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (!Regex.IsMatch(value, this.facultyNumberPattern))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.Append($"Faculty number: {this.FacultyNumber}");

            return output.ToString();
        }

        private static void ValidateStudentName(string name, int minLength, string argument)
        {
            if (name.Length < minLength)
            {
                throw new ArgumentException($"Expected length at least {minLength} symbols! Argument: {argument}");
            }
        }
    }
}