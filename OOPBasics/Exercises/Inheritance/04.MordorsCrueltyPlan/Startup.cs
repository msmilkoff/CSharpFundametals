namespace _04.MordorsCrueltyPlan
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Foods;
    using Factories;

    using static Mood;

    public class Startup
    {
        public static void Main()
        {
            var foods = new List<Food>();
            var factory = new FoodFactory();
            string input = Console.ReadLine();
            string[] foodInfo = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in foodInfo)
            {

                var food = factory.CreateFood(entry);
                foods.Add(food);
            }

            int totalHappinessPoints = foods.Sum(f => f.GetHappinessPoints());

            Mood? mood = null;
            if (totalHappinessPoints < -5)
            {
                mood = Angry;
            }
            else if (totalHappinessPoints >= -5 && totalHappinessPoints < 0)
            {
                mood = Sad;
            }
            else if (totalHappinessPoints >= 0 && totalHappinessPoints <= 15)
            {
                mood = Happy;
            }
            else if (totalHappinessPoints > 15)
            {
                mood = JavaScript;
            }

            Console.WriteLine(totalHappinessPoints);
            Console.WriteLine(mood);
        }
    }
}
