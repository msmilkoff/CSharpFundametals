namespace _02.KingsGambit
{
    using System;

    public class Footman : Unit
    {
        public Footman(string name)
            : base(name)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}