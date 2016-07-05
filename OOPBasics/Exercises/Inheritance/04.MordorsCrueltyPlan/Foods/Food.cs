namespace _04.MordorsCrueltyPlan.Foods
{
    public abstract class Food
    {
        private int DefaultHappinesPoits = -1;

        public abstract int GetHappinessPoints();

        protected int GetDefaultHappinesPoints() => DefaultHappinesPoits;
    }
}