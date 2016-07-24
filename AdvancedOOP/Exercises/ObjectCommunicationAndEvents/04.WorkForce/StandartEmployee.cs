namespace _04.WorkForce
{
    public class StandartEmployee : Employee
    {
        private const int StandartEmployeeWorkHours = 40;

        public StandartEmployee(string name)
            : base(name)
        {
        }

        public override int WorkHoursPerWeek => StandartEmployeeWorkHours;
    }
}