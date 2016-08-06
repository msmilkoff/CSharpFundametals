namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> 
        where T : IComparable<T>
    {
        void Add(T item);

        void AddRange(ICollection<T> collection);

        int Size { get; }

        string JoinWith(string joiner);
    }
}