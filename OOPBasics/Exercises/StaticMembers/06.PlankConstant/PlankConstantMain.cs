namespace _06.PlankConstant
{
    using System;

    public class PlankConstantMain
    {
        public static void Main()
        {
            Console.WriteLine(Calculation.GetReducedPlankConstant());
        }
    }

    public class Calculation
    {
        private const double PlanckConstant = 6.62606896e-34;
        private const double Pi = 3.14159;

        public static double GetReducedPlankConstant()
        {

            double result = PlanckConstant / (2 * Pi);

            return result;
        }
    }
}