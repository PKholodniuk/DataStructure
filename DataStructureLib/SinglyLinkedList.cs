﻿using DataStructure.Contracts;

namespace DataStructureLib
{
    public class SinglyLinkedList<T> : IMyList<T>
    {
        public class Node
        {
            public T Data { get; }
            public Node? Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }

            public Node(T data, Node next) : this(data)
            {
                Next = next;
            }
        }

        public int Count { get; private set; } = 0;
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        public void Add(T data)
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

        public void AddFirst(T data)
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

        public void Insert(int index, T? data)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                Node? current = First;
                Node? previos = null;
                for (int i = 0; i < index && current != null; i++, current = current.Next)
                {
                    previos = current;
                }

                if (previos != null)
                {
                    var newNode = new Node(data, current);
                    previos.Next = newNode;

                    Count++;
                }
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
                Node? current = First;

                for (int i = 0; i < Count; i++)
                {
                    if (current.Data.Equals(data))
                        return true;

                    current = current?.Next;
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
                current = current.Next;
            }
            return array;
        }
    }
}
