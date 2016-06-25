namespace _09.CatLady
{
    public class Cymric : Cat
    {
        public Cymric(string name, double furLength)
            : base(name)
        {
            this.FurLength = furLength;
        }

        public double FurLength { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.FurLength:F2}";
        }
    }
}