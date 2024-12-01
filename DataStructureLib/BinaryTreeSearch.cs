namespace DataStructureLib
{
    public class BinaryTreeSearch
    {
        public class Node
        {
            public int Value { get; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public Node(int value, Node? left, Node right) : this(value)
            {
                Left = left;
                Right = right;
            }
        }

        public int Count { get; private set; }
        public Node? Root { get; private set; }

        public void Add(int value)
        {
            Root = AddNode(value, Root);
        }

        private Node AddNode(int value, Node? root)
        {
            if (root == null)
            {
                root = new Node(value);
                Count++;
                return root;
            }
            else
            {
                if (value < root.Value)
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

        public bool Contains(int value)
        {
            return Contains(value, Root);
        }

        private bool Contains(int value, Node? root)
        {
            if (root == null)
            {
                return false;
            }

            if (value == root.Value)
            {
                return true;
            }

            if (value < root.Value)
            {
                return Contains(value, root.Left);
            }
            else
            {
                return Contains(value, root.Right);
            }
        }

        public int[] ToArray()
        {
            var array = new int[Count];
            AddToArray(Root, array, 0);

            return array;
        }

        private int AddToArray(Node node, int [] array, int index)
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
