namespace _02.KingsGambit
{
    public abstract class Unit : IUnit
    {
        private string name;

        protected Unit(string name)
        {
            this.Name = name;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }

            private set { this.name = value; }
        }

        public bool IsAlive { get; set; }

        public abstract void RespondToAttack();
    }
}