using System;

namespace _04.MordorsCrueltyPlan.Foods
{
    public class NonSpecifiedFood : Food
    {
        public override int GetHappinessPoints() => base.GetDefaultHappinesPoints();
    }
}