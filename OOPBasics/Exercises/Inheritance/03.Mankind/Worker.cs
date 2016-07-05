namespace _03.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const int MinLastNameLength = 3;
        private const decimal MinWeekSalary = 10.0m;
        private const double MinWorkingHours = 1.0;
        private const double MaxWorkingHours = 12.0;
        private const int WorkDaysPerWeek = 5;

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public override string LastName
        {
            get { return base.LastName; }
            protected set
            {
                if (value.Length < MinLastNameLength)
                {
                    throw new ArgumentException($"Expected length at least {MinLastNameLength} symbols! Argument: lastName ");
                }

                base.LastName = value;
            }
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            protected set
            {
                if (value <= MinWeekSalary)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < MinWorkingHours || value > MaxWorkingHours)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            output.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
            output.Append($"Salary per hour: {this.GetSalaryPerHour():F2}");

            return output.ToString();
        }

        private decimal GetSalaryPerHour()
        {
            decimal salaryPerDay = this.weekSalary / WorkDaysPerWeek;
            decimal salaryPerHour = salaryPerDay / (decimal)this.WorkHoursPerDay;

            return salaryPerHour;
        }
    }
}