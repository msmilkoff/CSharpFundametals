namespace _05.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class PhoneBook
    {
        public static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            const string pattern = @"(\w.*)-(.*)";

            string command = Console.ReadLine();
            while (command != "search" && command != "stop")
            {
                if (Regex.IsMatch(command, pattern))
                {
                    var match = Regex.Match(command, pattern);
                    string name = match.Groups[1].Value;
                    string phone = match.Groups[2].Value;

                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, phone);
                    }
                    else
                    {
                        phonebook[name] = phone;
                    }
                }

                command = Console.ReadLine();
            }

            if (command == "search")
            {
                FindContacts(phonebook);
            }
            else if (command == "stop")
            {
                FindContacts(phonebook);

                Environment.Exit(0);
            }
        }

        private static void FindContacts(Dictionary<string, string> phonebook)
        {
            var command = Console.ReadLine();
            while (command != "stop")
            {
                if (phonebook.ContainsKey(command))
                {
                    Console.WriteLine($"{command} -> {phonebook[command]}");
                }
                else
                {
                    Console.WriteLine($"Contact {command} does not exist.");
                }

                command = Console.ReadLine();
            }
        }
    }
}