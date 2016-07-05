namespace _04.MordorsCrueltyPlan.Foods
{
    public class Cram : Food
    {
        private const int HappinessPoints = 2;

        public override int GetHappinessPoints() => HappinessPoints;
    }
}