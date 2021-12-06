using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1.Services.Abstractions
{
    public interface ICustomList<T>
    {
        int Count { get; set; }

        int Capacity { get; set; }

        IReadOnlyCollection<T> GetCollection();

        void Add(T item);

        void AddRange(T[] items);

        void AddRange(CustomList<T> items);

        bool RemoveAt(int index);
        bool Remove(Predicate<T> predicate);

        void Sort(IComparer<T> comparer);

        void Trim();
    }
}
