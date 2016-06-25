namespace _07.Google
{
    public class Pokemon : INameable
    {
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }
}