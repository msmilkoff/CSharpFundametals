namespace _0102.ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            ListyIterator<string> listy = null;

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Create":
                        if (tokens.Length == 1)
                        {
                            listy = new ListyIterator<string>();
                        }
                        else
                        {
                            var collection = tokens.Skip(1);
                            listy = new ListyIterator<string>(collection);
                        }
                        break;
                    case "Move":
                        bool moveResult = listy.Move();
                        Console.WriteLine(moveResult.ToString());
                        break;
                    case "HasNext":
                        bool hasNextResult = listy.HasNext();
                        Console.WriteLine(hasNextResult);
                        break;
                    case "Print":
                        try
                        {
                            listy.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        break;
                    case "End":
                        Environment.Exit(0);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
        private int currentIndex;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.currentIndex = 0;
        }

        public ListyIterator(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
        }

        public bool Move()
        {
            if (this.currentIndex >= this.collection.Count - 1)
            {
                return false;
            }

            this.currentIndex++;
            return true;
        }

        public bool HasNext()
        {
            return this.currentIndex < this.collection.Count - 1;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[this.currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.collection));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
