using DataStructure.Contracts;
using System;

namespace DataStructureLib
{
    public class DoublyLinkedList<T> : IMyList<T>
    {
        public class Node
        {
            public T Data { get; }
            public Node? Previous { get; set; }
            public Node? Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }

            public Node(T data, Node next) : this(data)
            {
                Next = next;
            }

            public Node(T data, Node next, Node previous) : this(data, next)
            {
                Previous = previous;
            }
        }

        public int Count { get; private set; } = 0;
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        public void Add(T data)
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

        public void AddFirst(T data)
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

        public void Insert(int index, T data)
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

        public void Remove(T data)
        {
            Node current = First;

            for (int i = 0; i < Count; i++)
            {
                if (i == 0 && current.Data.Equals(data))
                {
                    RemoveFirst();
                    break;
                }
                if (current.Data.Equals(data))
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

        public bool Contains(T data)
        {
            if (Count >= 1)
            {
                Node current = First;

                for (int i = 0; i < Count; i++)
                {
                    if (current.Data.Equals(data))
                        return true;

                    current = current.Next;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            var array = new T[Count];

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