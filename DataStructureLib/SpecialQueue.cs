using DataStructure.Contracts;

namespace DataStructureLib
{
    public class SpecialQueue<T> : ISpecialDataStructure<T>
    {
        DoublyLinkedList<T> list = new DoublyLinkedList<T>();

        public int Count { get; private set; } = 0;

        public void Enqueue(T data)
        {
            list.Add(data);
            Count++;
        }

        public T? Dequeue()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T data = list.First.Data;
            list.RemoveFirst();
            Count--;
            return data;
        }

        public bool Contains(T data)
        {
            return list.Contains(data);
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }

        public T? Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return list.First.Data;
        }

        public T[] ToArray()
        {
            return list.ToArray();
        }
    }
}
