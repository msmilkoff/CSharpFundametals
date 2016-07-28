namespace _01.Database
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Database : IEnumerable<int>
    {
        private const int Capacity = 16;

        private int currentIndex;
        private int[] items;

        public Database()
        {
            this.currentIndex = 0;
            this.items = new int[Capacity];
        }

        public int Length => items.Length;

        public int Last => this.items[currentIndex - 1];

        public Database(params int[] elements)
        {
            if (elements.Length > 16)
            {
                throw new InvalidOperationException($"Cannot initialize Database with more than {Capacity} items.");
            }

            this.items = new int[Capacity];
            for (int i = 0; i < elements.Length; i++)
            {
                this.items[i] = elements[i];
            }

            this.currentIndex = elements.Length;
            
        }

        public void Add(int item)
        {
            if (this.currentIndex >= 16)
            {
                throw new InvalidOperationException("Cannot add more than 16 items.");
            }

            this.items[currentIndex] = item;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Database empty.");
            }

            int removeIndex = this.currentIndex - 1;
            this.items[removeIndex] = 0;
            this.currentIndex--;
        }

        public int[] FetchAll()
        {
            int[] result = new int[this.items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.items[i];
            }

            return result;
        }

        private void InitItems(int[] inputElements)
        {
            for (int i = 0; i < Capacity; i++)
            {
                this.items[i] = inputElements[i];
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}