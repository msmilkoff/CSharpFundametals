namespace _09.CatLady
{
    public class Siamese : Cat
    {
        public Siamese(string name, int earSize)
            : base(name)
        {
            this.EarSize = earSize;
        }

        public int EarSize  { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {base.ToString()} {this.EarSize}";
        }
    }
}