namespace DataStructureLib
{
    public class SinglyLinkedList
    {
        public class Node
        {
            public object Data { get; set; }
            public Node? Next { get; set; }

            public Node(object data)
            {
                Data = data;
            }

            public Node(object data, Node next) : this(data)
            {
                Next = next;
            }
        }

        public int Count { get; set; } = 0;
        public Node? First { get; set; }
        public Node? Last { get; set; }

        public void Add(object data)
        {
            if (First == null)
            {
                First = new Node(data);
                Last = new Node(data);
            }
            else
            {
                Node? current = First;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                Last = new Node(data);

                current.Next = Last;
            }
            Count++;
        }

        public void AddFirst(object data)
        {
            if (Count == 0)
            {
                First = new Node(data);
                Last = new Node(data);
            }
            else
            {
                Node? current = new Node(data, First);

                First = current;
            }
            Count++;
        }

        public void Insert(int index, object data)
        {
            if (index >= 0 && index <= Count)
            {
                if (index == 0)
                {
                    AddFirst(data);
                }
                else
                {
                    Node? current = First;
                    Node? inserted = new Node(data);

                    for (int i = 0; i <= Count; i++)
                    {
                        if (index - i == 1)
                        {
                            inserted = new Node(data, current?.Next);
                            current.Next = inserted;

                            Count++;
                            break;
                        }
                        if (i == Count)
                        {
                            Last = inserted;

                            current.Next = Last;

                            Count++;
                            break;
                        }
                        current = current?.Next;
                    }
                }
            }
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(object data)
        {
            if (Count >= 1)
            {
                Node? current = First;

                for (int i = 0; i < Count; i++)
                {
                    if (current?.Data == data)
                        return true;

                    current = current?.Next;
                }
            }

            return false;
        }

        public object[] ToArray()
        {
            var array = new object[Count];

            Node? current = First;

            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current?.Next;
            }
            return array;
        }
    }
}
