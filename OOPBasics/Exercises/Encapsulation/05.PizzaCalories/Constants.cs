namespace _05.PizzaCalories
{
    public static class Constants
    {
        public const double WhiteDoughModifier = 1.5;
        public const double WholegrainDoughModifier = 1.0;
        public const double CrispyDoughModifier = 0.9;
        public const double ChewyDoughModifier = 1.1;
        public const double HomemadeDoughModifier = 1.0;

        public const double MinDoughWeight = 1;
        public const double MaxDoughWeight = 200;

        public const double MeatModifier = 1.2;
        public const double VeggiesModifier = 0.8;
        public const double CheeseModifier = 1.1;
        public const double SauceModifier = 0.9;

        public const double MinToppingWeight = 1;
        public const double MaxToppingWeight = 50;

        public const int MaxPizzaLength = 15;
        public const int MaxAmountOfToppings = 10;
    }
}