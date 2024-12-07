using System.Collections.Generic;
using DataStructure.Contracts;

namespace DataStructureLib
{
    public class SpecialList<T> : IMyList<T>
    {
        private T[] innerArray = new T[5];

        private int count = 0;

        public int Count
        {
            get 
            { 
                return count; 
            } 
        }

        private void ExtendInnerArray()
        {
            if (count == innerArray.Length)
            {
                var newArray = new T[innerArray.Length * 2];
                innerArray.CopyTo(newArray, 0);
                innerArray = newArray;
            }
        }

        private void DecreaseInnerArray()
        {
            if (count * 4 < innerArray.Length )
            {
                var newArray = new T[innerArray.Length / 2];
                innerArray.CopyTo(newArray, 0);
                innerArray = newArray;
            }
        }

        public void Add(T value)
        {
            ExtendInnerArray();

            innerArray[count] = value;
            count++;
        }

        public void Insert(int index, T value)
        {
            if (index >= 0 && index < count)
            {
                ExtendInnerArray();

                count++;

                for (int i = Count - 1; i > index; i--)
                {
                    innerArray[i] = innerArray[i-1];
                }

                innerArray[index] = value;
            }
        }

        public void Remove(T value) 
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index) 
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - index - 1; i++)
                {
                    innerArray[i] = innerArray[i + 1];
                }

                count--;

                DecreaseInnerArray();
            }
        }

        public void Clear()
        {
            innerArray = new T[innerArray.Length];
            count = 0;
        }

        public bool Contains(T value) 
        {
            for (int i = 0; i < count; i++)
            {
                if (innerArray[i].Equals(value))
                {
                    return true;
                }
            }

            return false; 
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (innerArray[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public T[] ToArray()
        {
            var newArray = new T[count];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = innerArray[i];
            }

            innerArray = newArray;

            return innerArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < count/2; i++ )
            {
                T temp = innerArray[i];
                innerArray[i] = innerArray[count - 1 - i];
                innerArray[count - 1 - i] = temp;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return innerArray[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index is out of range.");
                innerArray[index] = value;
            }
        }
    }
}
