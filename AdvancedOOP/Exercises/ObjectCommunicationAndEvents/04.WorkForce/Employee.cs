namespace _04.WorkForce
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual int WorkHoursPerWeek { get; private set; }
    }
}