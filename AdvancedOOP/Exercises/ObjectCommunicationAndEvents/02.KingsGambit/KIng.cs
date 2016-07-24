using System;

namespace _02.KingsGambit
{
    public class King : Unit
    {
        public King(string name) 
            : base(name)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}