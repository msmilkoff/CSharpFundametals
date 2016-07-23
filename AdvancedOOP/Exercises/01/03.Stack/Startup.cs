namespace _03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var stack = new CustomStack<string>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Push":
                        var itemsToPush = tokens.Skip(1);
                        foreach (var item in itemsToPush)
                        {
                            stack.Push(item);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            PrintStack(stack);
        }

        private static void PrintStack(CustomStack<string> stack)
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    public class CustomStack<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 16;
        private int top;
        private T[] items;

        public CustomStack(int capacity = DefaultCapacity)
        {
            this.items = new T[capacity];
            this.top = 0;
        }

        public int Count => this.top;

        public void Push(T item)
        {
            if (this.top >= this.items.Length)
            {
                this.Resize();
            }

            this.items[this.top] = item;
            this.top++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T poppedItem = this.items[this.top - 1];

            this.items[this.top - 1] = default(T);
            this.top--;

            return poppedItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] newItems = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                newItems[i] = this.items[i];
            }

            this.items = newItems;
        }
    }
}
