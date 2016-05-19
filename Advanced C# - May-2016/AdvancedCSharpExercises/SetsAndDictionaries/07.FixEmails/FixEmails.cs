namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main(string[] args)
        {
            var contacts = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "stop")
                {
                    break;
                }

                string email = Console.ReadLine();
                bool isvalidEmail = !(email.EndsWith("us") || email.EndsWith("uk"));
                if (!contacts.ContainsKey(input) && isvalidEmail)
                {
                    contacts.Add(input, email);
                }

                input = Console.ReadLine();
            }


            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }
    }
}
