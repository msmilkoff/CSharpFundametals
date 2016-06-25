namespace _07.Google
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person : INameable
    {
        public Person(string name)
        {
            this.Name = name;
            this.Pokemon = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public ICollection<Pokemon> Pokemon { get; set; }

        public ICollection<Parent> Parents { get; set; }

        public ICollection<Child> Children { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{this.Name}");
            output.AppendLine("Company:");
            output.Append(this.Company == null ? string.Empty : $"{this.Company}\n");
            output.AppendLine("Car:");
            output.Append(this.Car == null ? string.Empty : $"{this.Car}\n");
            output.AppendLine("Pokemon:");
            output.Append(this.Pokemon.Any() ? $"{string.Join("\n", this.Pokemon)}\n" : string.Empty);
            output.AppendLine("Parents:");
            output.Append(this.Parents.Any() ? $"{string.Join("\n", this.Parents)}\n" : string.Empty);
            output.AppendLine("Children:");
            output.Append(this.Children.Any() ? $"{string.Join("\n", this.Children)}\n" : string.Empty);

            return output.ToString();
        }
    }
}