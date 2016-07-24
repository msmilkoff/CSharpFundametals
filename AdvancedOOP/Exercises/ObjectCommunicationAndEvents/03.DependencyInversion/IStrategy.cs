namespace _03.DependencyInversion
{
    public interface IStrategy
    {
        int PerformOperation(int firstNumber, int secondNumber);
    }
}