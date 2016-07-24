namespace _03.DependencyInversion
{
    public class DivisionStrategy : IStrategy
    {
        public int PerformOperation(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}