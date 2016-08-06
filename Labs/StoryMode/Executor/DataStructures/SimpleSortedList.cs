namespace Executor.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private Comparison<T> comparison;

        public SimpleSortedList(Comparison<T> comparison, int capacity)
        {
            this.comparison = comparison;
            this.InitCollection(capacity);
        }

        public SimpleSortedList(int capacity)
            :this((x, y) => x.CompareTo(y), capacity)
        {
        }

        public SimpleSortedList(Comparison<T> comparison)
            :this(comparison, DefaultSize)
        {
        }

        public SimpleSortedList()
            :this((x, y) => x.CompareTo(y), DefaultSize)
        {
        }

        public int Size => this.size;

        public void Add(T item)
        {
            if (this.innerCollection.Length >= this.Size)
            {
                this.Resize();
            }

            this.innerCollection[this.size] = item;
            this.size++;

            // Optimization will be implemented later.
            Array.Sort(this.innerCollection, 0, this.size);
        }


        public void AddRange(ICollection<T> collection)
        {
            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var item in collection)
            {
                this.innerCollection[this.size] = item;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size);
        }

        public string JoinWith(string joiner)
        {
            var result = new StringBuilder();
            foreach (var item in this)
            {
                result.Append(item);
                result.Append(joiner);
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();    
        }

        private void InitCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative.");
            }

            this.innerCollection = new T[capacity];
        }

        private void Resize()
        {
            var newCollection = new T[this.Size * 2];
            Array.Copy(this.innerCollection, newCollection, this.Size);

            this.innerCollection = newCollection;
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }
    }
}