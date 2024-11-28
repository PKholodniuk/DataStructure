namespace DataStructureLib
{
    public class SpecialStak
    {
        DoublyLinkedList list = new DoublyLinkedList();

        public int Count { get; set; } = 0;

        public void Push(object data)
        {
            list.AddFirst(data);
            Count++;
        }

        public object Pop()
        {
            if (list.Count == 0)
            {
                return null;
            }

            object data = list.First.Data;
            list.RemoveFirst();
            Count--;
            return data;
        }

        public bool Contains(object data)
        {
            return list.Contains(data);
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }

        public object Peek()
        {
            if (Count == 0)
            {
                return list.First;
            }

            return list.First.Data;
        }

        public object[] ToArray()
        {
            return list.ToArray();
        }
    }
}
