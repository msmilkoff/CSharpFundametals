namespace _01HarestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string input = Console.ReadLine();
            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        foreach (var field in fields)
                        {
                            if (field.IsPrivate)
                            {
                                Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;
                    case "public":
                        foreach (var field in fields)
                        {
                            if (field.IsPublic)
                            {
                                Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;
                    case "protected":
                        foreach (var field in fields)
                        {
                            if (field.IsFamily)
                            {
                                Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;
                    case "all":
                        foreach (var field in fields)
                        {
                            Console.WriteLine($"{GetFieldModifier(field)} {field.FieldType.Name} {field.Name}");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }

        public static string GetFieldModifier(FieldInfo field)
        {
            if (field.IsPrivate)
            {
                return "private";
            }
            else if (field.IsPublic)
            {
                return "public";
            }
            else if (field.IsAssembly)
            {
                return "internal";
            }
            else
            {
                return "protected";
            }
        }
    }
}
