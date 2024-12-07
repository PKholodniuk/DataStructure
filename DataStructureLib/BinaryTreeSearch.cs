using DataStructure.Contracts;

namespace DataStructureLib
{
    public class BinaryTreeSearch<T> : IBinaryTreeSearch<T>  where T : IComparable<T>
    {
        public class Node
        {
            public T Value { get; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public Node(T value, Node? left, Node right) : this(value)
            {
                Left = left;
                Right = right;
            }
        }

        public int Count { get; private set; }
        public Node? Root { get; private set; }

        public void Add(T value)
        {
            Root = AddNode(value, Root);
        }

        private Node AddNode(T value, Node? root)
        {
            if (root == null)
            {
                root = new Node(value);
                Count++;
                return root;
            }
            else
            {
                if (value.CompareTo(root.Value) < 0)
                {
                    root.Left = AddNode(value, root.Left);
                    return root;
                }
                else
                {
                    root.Right = AddNode(value, root.Right);
                    return root;
                }
            }
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            return Contains(value, Root);
        }

        private bool Contains(T value, Node? root)
        {
            if (root == null)
            {
                return false;
            }

            if (value.CompareTo(root.Value) == 0)
            {
                return true;
            }

            if (value.CompareTo(root.Value) < 0)
            {
                return Contains(value, root.Left);
            }
            else
            {
                return Contains(value, root.Right);
            }
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            AddToArray(Root, array, 0);

            return array;
        }

        private int AddToArray(Node node, T [] array, int index)
        {
            if (node == null)
            {
                return index;
            }

            array[index] = node.Value;
            index++;

            index = AddToArray(node.Left, array, index);
            index = AddToArray(node.Right, array, index);

            return index;
        }
    }
}
