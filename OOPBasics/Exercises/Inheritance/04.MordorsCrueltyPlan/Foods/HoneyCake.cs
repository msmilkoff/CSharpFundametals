namespace _04.MordorsCrueltyPlan.Foods
{
    public class HoneyCake : Food
    {
        private const int HappinessPoints = 5;

        public override int GetHappinessPoints() => HappinessPoints;
    }
}