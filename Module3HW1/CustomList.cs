using System;
using System.Collections;
using System.Collections.Generic;
using Module3HW1.Models;
using Module3HW1.Services.Abstractions;
using Module3HW1.Services.Comparers;

namespace Module3HW1
{
    public class CustomList<T> : ICustomList<T>
    {
        private T[] _array;
        private int _capacity;

        public CustomList(int capacity = 5)
        {
            _capacity = capacity;
            _array = new T[capacity];
        }

        public int Count { get; set; }

        public int Capacity
        {
            get
            {
                return _capacity;
            }

            set
            {
                if (value < Count)
                {
                    value = Count;
                }

                _capacity = value;

                SetCapacity();
            }
        }

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public IReadOnlyCollection<T> GetCollection()
        {
            return _array;
        }

        public void Add(T item)
        {
            if (Count < _capacity)
            {
                _array[Count++] = item;
            }
            else
            {
                Capacity = Capacity * 2;
            }
        }

        public void AddRange(T[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void AddRange(CustomList<T> items)
        {
            var count = items.Count;
            for (var counter = 0; counter < count; counter++)
            {
                Add(items[counter]);
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || _array[index] == null)
            {
                return false;
            }

            var counter = index;

            for (; counter < Count; counter++)
            {
                if (Count == counter + 1)
                {
                    _array[counter] = default(T);
                }
                else
                {
                    _array[counter] = _array[counter + 1];
                }
            }

            Count--;

            return true;
        }

        public bool Remove(Predicate<T> predicate)
        {
            var index = Array.FindIndex<T>(_array,  0, predicate);

            if (index < 0)
            {
                return false;
            }

            return RemoveAt(index);
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf<T>(_array, item);

            if (index < 0)
            {
                return false;
            }

            return RemoveAt(index);
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort<T>(_array, comparer);
        }

        public IEnumerator GetEnumerator()
        {
             return _array.GetEnumerator();
        }

        public void Trim()
        {
            _capacity = Count;
            SetCapacity();
        }

        private void SetCapacity()
        {
            Array.Resize(ref _array, _capacity);
        }
    }
}
