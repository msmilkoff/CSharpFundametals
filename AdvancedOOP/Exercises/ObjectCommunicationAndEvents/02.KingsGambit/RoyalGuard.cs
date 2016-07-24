namespace _02.KingsGambit
{
    using System;

    public class RoyalGuard : Unit
    {
        public RoyalGuard(string name)
            : base(name)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}