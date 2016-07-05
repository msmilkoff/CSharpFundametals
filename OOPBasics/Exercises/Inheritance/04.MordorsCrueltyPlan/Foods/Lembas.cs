namespace _04.MordorsCrueltyPlan.Foods
{
    public class Lembas : Food
    {
        private const int HappinessPoints = 3;

        public override int GetHappinessPoints() => HappinessPoints;
    }
}