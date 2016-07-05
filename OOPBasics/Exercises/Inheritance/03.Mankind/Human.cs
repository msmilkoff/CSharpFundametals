namespace _03.Mankind
{
    using System;
    using System.Text;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                ValidateName(value, "firstName");
                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            protected set
            {
                ValidateName(value, "lastName");
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"First Name: {this.FirstName}");
            output.AppendLine($"Last Name: {this.LastName}");

            return output.ToString();
        }

        private static void ValidateName(string name, string argument)
        {
            if (!char.IsUpper(name[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {argument}");
            }
        }
    }
}