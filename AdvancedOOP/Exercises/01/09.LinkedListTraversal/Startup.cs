namespace _09.LinkedListTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var linkedList = new SinglyLinkedList<int>();

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                if (command == "Add")
                {
                    linkedList.Add(number);
                }
                else if (command == "Remove")
                {
                    linkedList.Remove(number);
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }

    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> list;

        public SinglyLinkedList()
        {
            this.list = new LinkedList<T>();
        }

        public int Count => this.list.Count;

        public void Add(T item)
        {
            this.list.AddLast(item);
        }

        public bool Remove(T item)
        {
            return this.list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
