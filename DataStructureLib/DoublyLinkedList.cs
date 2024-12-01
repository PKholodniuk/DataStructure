using System;

namespace DataStructureLib
{
    public class DoublyLinkedList
    {
        public class Node
        {
            public object Data { get; }
            public Node? Previous { get; set; }
            public Node? Next { get; set; }

            public Node(object data)
            {
                Data = data;
            }

            public Node(object data, Node next) : this(data)
            {
                Next = next;
            }

            public Node(object data, Node next, Node previous) : this(data, next)
            {
                Previous = previous;
            }
        }

        public int Count { get; private set; } = 0;
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        public void Add(object data)
        {
            if (Count == 0)
            {
                First = new Node(data);
                Last = new Node(data);
            }
            else
            {
                Node? current = First;

                while (current?.Next != null)
                {
                    current = current.Next;
                }

                Last = new Node(data);

                Last.Previous = current;

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
            if (Count == 1)
            {
                Node current = new Node(data, First);

                Last.Previous = current;
                First.Previous = current;

                First = current;
            }
            else
            {
                Node current = new Node(data, First);

                First.Previous = current;

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
                    Node current = First;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }

                    Node newNode = new Node(data, next: current.Next, previous: current);

                    if (current.Next != null)
                    {
                        current.Next.Previous = newNode;
                    }
                    else
                    {
                        Last = newNode;
                    }

                    current.Next = newNode;
                    Count++;
                }
            }
        }

        public void Remove(object data)
        {
            Node current = First;

            for (int i = 0; i < Count; i++)
            {
                if (i == 0 && current.Data == data)
                {
                    RemoveFirst();
                    break;
                }
                if (current.Data == data)
                {
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                        current.Previous.Next = current.Next;

                        Count--;
                        break;
                    }
                    else
                    {
                        RemoveLast();
                        break;
                    }
                }
                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else if (Count == 2 && Last != null)
            {
                First = null;
                First = Last;
                First.Previous = null;
                Last = null;
            }
            else
            {
                First = First.Next;

                First.Previous = null;
            }
            Count--;
            return;
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                Last = null;
                First = null;
                Count--;
                return;
            }
            if (Count == 2)
            {
                First.Next = null;
                Last = First;
                Count--;
            }
            else
            {
                Last.Previous.Next = null;

                Last = Last.Previous;
                Count--;
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