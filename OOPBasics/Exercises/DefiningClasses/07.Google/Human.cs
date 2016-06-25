namespace _07.Google
{
    public class Human : INameable
    {
        public Human(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }

        public string Name { get; set; }

        public string BirthDay { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.BirthDay}";
        }
    }
}