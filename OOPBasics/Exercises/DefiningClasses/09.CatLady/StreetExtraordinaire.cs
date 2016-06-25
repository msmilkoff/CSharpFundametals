namespace _09.CatLady
{
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string name, int decibels)
            : base(name)
        {
            this.Decibels = decibels;
        }

        public int Decibels { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.Decibels}";
        }
    }
}