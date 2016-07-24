namespace _03.DependencyInversion
{
    public class SubtractionStrategy : IStrategy
    {
        public int PerformOperation(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}