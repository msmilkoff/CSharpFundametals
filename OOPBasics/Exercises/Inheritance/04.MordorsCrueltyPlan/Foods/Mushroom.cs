namespace _04.MordorsCrueltyPlan.Foods
{
    public class Mushroom : Food
    {
        private const int HappinessPoints = -10;

        public override int GetHappinessPoints() => HappinessPoints;
    }
}