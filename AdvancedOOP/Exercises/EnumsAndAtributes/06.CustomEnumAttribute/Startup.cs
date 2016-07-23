namespace _06.CustomEnumAttribute
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            // Problem solution is incorporated in 01-05.Cards to avoid code duplication.
        }
    }

    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Type = Enumeration, Description = Provides {this.Category.ToLower()} constants for a Card class.";
        }
    }
}
