namespace _03.DependencyInversion
{
    public class MultiplicationStrategy : IStrategy
    {
        public int PerformOperation(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}