namespace _03.Iterator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            ListIterator iterator = null;

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                try
                {
                    iterator = StartExecutingCommands(iterator, tokens);
                }
                catch (InvalidOperationException ioEx)
                {
                    Console.WriteLine(ioEx.Message);
                }
                catch (ArgumentNullException anEx)
                {
                    Console.WriteLine(anEx.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static ListIterator StartExecutingCommands(ListIterator iterator, string[] tokens)
        {
            switch (tokens[0])
            {
                case "Create":
                    iterator = new ListIterator(tokens.Skip(1).ToArray());
                    break;
                case "Move":
                    Console.WriteLine(iterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(iterator.HasNext());
                    break;
                case "Print":
                    iterator.Print();
                    break;
            }

            return iterator;
        }
    }
}
