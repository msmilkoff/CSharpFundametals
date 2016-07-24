namespace _02.KingsGambit
{
    public interface IUnit
    {
        string Name { get; }

        bool IsAlive { get; }

        void RespondToAttack();
    }
}