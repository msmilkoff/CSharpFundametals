namespace _04.WorkForce
{
    using System;

    public class Job
    {
        public event JobDoneEventHandler JobDone;

        private string name;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.name = name;
            this.HoursOfWorkRequired = hoursRequired;
            this.Employee = employee;
        }

        public string Name => this.name;

        public int HoursOfWorkRequired { get; private set; }

        public IEmployee Employee { get; private set; }

        public bool IsJobDone { get; private set; }

        public void Update()
        {
            int currentHoursRequired = this.HoursOfWorkRequired;
            this.HoursOfWorkRequired = currentHoursRequired - this.Employee.WorkHoursPerWeek;
            if (this.HoursOfWorkRequired <= 0)
            {
                this.OnJobDone();
            }
        }

        public void OnJobDone()
        {
            if (this.JobDone != null)
            {
                this.JobDone();
            }
            else
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.IsJobDone = true;
            }
        }
        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }

    public delegate void JobDoneEventHandler();
}