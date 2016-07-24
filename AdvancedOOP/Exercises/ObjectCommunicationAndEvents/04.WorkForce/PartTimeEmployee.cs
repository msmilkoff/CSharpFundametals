namespace _04.WorkForce
{
    public class PartTimeEmployee : Employee
    {
        private const int PartTimeEmployeeWorkHours = 20;

        public PartTimeEmployee(string name)
            : base(name)
        {
        }

        public override int WorkHoursPerWeek => PartTimeEmployeeWorkHours;
    }
}