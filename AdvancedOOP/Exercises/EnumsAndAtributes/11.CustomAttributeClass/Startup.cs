namespace _11.CustomAttributeClass
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var classType = typeof(TestClass);
            var attr = Attribute.GetCustomAttribute(classType, typeof(CustomAttribute));
            var customAttr = attr as CustomAttribute;

            string input = Console.ReadLine();
            while (input != "END")
            {
                switch (input)
                {
                    case "Author":
                        Console.WriteLine($"Author: {customAttr.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {customAttr.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {customAttr.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", customAttr.Reviewers)}");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class TestClass
    {
    }

    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; private set; }

        public int Revision { get; private set; }

        public string Description { get; private set; }

        public string[] Reviewers { get; private set; }

    }
}
