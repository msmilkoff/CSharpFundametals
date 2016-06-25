namespace _09.CatLady
{
    public abstract class Cat
    {
        protected Cat(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}