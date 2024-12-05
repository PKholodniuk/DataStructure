using DataStructure.Contracts;

namespace DataStructureLib
{
    public class SpecialList : IMyList
    {
        private object[] innerArray = new object[5];

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
                var newArray = new object[innerArray.Length * 2];
                innerArray.CopyTo(newArray, 0);
                innerArray = newArray;
            }
        }

        private void DecreaseInnerArray()
        {
            if (count * 4 < innerArray.Length )
            {
                var newArray = new object[innerArray.Length / 2];
                innerArray.CopyTo(newArray, 0);
                innerArray = newArray;
            }
        }

        public void Add(object value)
        {
            ExtendInnerArray();

            innerArray[count] = value;
            count++;
        }

        public void Insert(int index, object value)
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

        public void Remove(object value) 
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
            innerArray = new object[innerArray.Length];
            count = 0;
        }

        public bool Contains(object value) 
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

        public int IndexOf(object value)
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

        public object[] ToArray()
        {
            var newArray = new object[count];

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
                object temp = innerArray[i];
                innerArray[i] = innerArray[count - 1 - i];
                innerArray[count - 1 - i] = temp;
            }
        }

        public object this[int index]
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
