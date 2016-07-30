namespace _03.Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        private List<string> items;
        private int internalIndex;

        public ListIterator(params string[] items)
        {
            ValidateForNullElements(items);
            this.items = new List<string>(items);
            this.internalIndex = 0;
        }

        public bool HasNext() => this.internalIndex < this.items.Count - 1;
        
        public bool Move()
        {
            if (this.HasNext())
            {
                this.internalIndex++;
                return true;
            }

            return false;
        }

        public string GetCurrentItem()
        {
            return this.items[this.internalIndex];
        }

        public void Print()
        {
            if (this.items.Count <= 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.internalIndex]);
        }

        private void ValidateForNullElements(string[] collection)
        {
            if (collection == null || collection.Any(s => s == null) || collection.Length == 0)
            {
                throw new ArgumentNullException();
            }
        }
    }
}