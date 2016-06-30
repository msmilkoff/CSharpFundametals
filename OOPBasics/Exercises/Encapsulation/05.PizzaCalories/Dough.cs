namespace _05.PizzaCalories
{
    using System;

    public enum FlourType
    {
        White,
        Wholegrain
    }

    public enum BakingTechnique
    {
        Crispy,
        Chewy,
        Homemade
    }

    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;

        private FlourType flourType;
        private BakingTechnique bakingTechnique;


        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = this.AssignFlourType(flourType);
            this.BakingTechnique = this.AssignBakingtechnique(bakingTechnique);
            this.Weight = weight;
            this.FlourTypeModifier = this.GetFlourTypeModifier();
            this.BakingTechniqueModifier = this.GetBakingTechniqueModifier();
        }

        private double FlourTypeModifier { get; }

        private double BakingTechniqueModifier { get; }

        private  FlourType FlourType
        {
            get { return this.flourType; }
            set { this.flourType = value; }
        }

        private BakingTechnique BakingTechnique
        {
            get { return this.bakingTechnique; }
            set { this.bakingTechnique = value; }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < Constants.MinDoughWeight || value > Constants.MaxDoughWeight)
                {
                    throw new ArgumentException(Messages.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            double result = (2 * this.Weight) * this.FlourTypeModifier * this.BakingTechniqueModifier;

            return result;
        }

        private FlourType AssignFlourType(string type)
        {
            FlourType result;
            bool isValidFlourType = Enum.TryParse(type, true, out result);
            if (!isValidFlourType)
            {
                throw new ArgumentException(Messages.InvalidDoughType);
            }

            return result;
        }

        private BakingTechnique AssignBakingtechnique(string type)
        {
            BakingTechnique result;
            bool isValidFlourType = Enum.TryParse(type, true, out result);
            if (!isValidFlourType)
            {
                throw new ArgumentException(Messages.InvalidDoughType);
            }

            return result;
        }

        private double GetFlourTypeModifier()
        {
            double result = double.NaN;
            switch (this.FlourType)
            {
                case FlourType.White:
                    result = Constants.WhiteDoughModifier;
                    break;
                case FlourType.Wholegrain:
                    result = Constants.WholegrainDoughModifier;
                    break;
            }

            return result;
        }

        private double GetBakingTechniqueModifier()
        {
            double result = double.NaN;
            switch (this.BakingTechnique)
            {
                case BakingTechnique.Chewy:
                    result = Constants.ChewyDoughModifier;
                    break;
                case BakingTechnique.Crispy:
                    result = Constants.CrispyDoughModifier;
                    break;
                case BakingTechnique.Homemade:
                    result = Constants.HomemadeDoughModifier;
                    break;
            }

            return result;
        }
    }
}