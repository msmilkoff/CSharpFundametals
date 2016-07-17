namespace _07_09.CustomListProblems
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class CustomList<T> : IEnumerable<T> 
        where T : IComparable
    {
        private List<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public CustomList(int capacity)
        {
            this.data = new List<T>(capacity);
        }

        public CustomList(IEnumerable<T> collection)
        {
            this.data = new List<T>(collection);
        }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public T Remove(int index)
        {
            T removedItem = this.data[index];
            this.data.RemoveAt(index);

            return removedItem;
        }

        public bool Contains(T item)
        {
            return this.data.Contains(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var item in this.data)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public void ForEach(Action<T> action)
        {
            this.data.ForEach(action);
        }

        public void Sort()
        {
            this.data.Sort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}