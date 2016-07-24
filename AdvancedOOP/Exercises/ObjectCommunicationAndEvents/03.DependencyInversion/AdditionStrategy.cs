namespace _03.DependencyInversion
{
    public class AdditionStrategy : IStrategy
    {
        public int PerformOperation(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}