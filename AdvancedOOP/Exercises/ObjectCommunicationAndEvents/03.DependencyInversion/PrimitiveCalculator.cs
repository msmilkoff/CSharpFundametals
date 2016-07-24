namespace _03.DependencyInversion
{
    public class PrimitiveCalculator
    {
        private readonly IStrategy InitialStrategy = new AdditionStrategy();
        private IStrategy currentStrategy;

        public PrimitiveCalculator()
        {
            this.currentStrategy = InitialStrategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.currentStrategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.currentStrategy.PerformOperation(firstOperand, secondOperand);
        }
    }
}