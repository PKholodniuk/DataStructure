using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class BinaryTreeSearchTest
    {
        [Test]
        public void NewBinaryTreeIsEmptyTest()
        {
            var tree = new BinaryTreeSearch<int>();

            Assert.That(tree.Count.Equals(0));
            Assert.IsNull(tree.Root);
        }

        #region Test Add method

        [Test]
        public void AddBinaryTreeTest()
        {
            var tree = new BinaryTreeSearch<int>();

            tree.Add(5);

            tree.Add(3);
            tree.Add(4);
            tree.Add(2);

            tree.Add(8);
            tree.Add(7);
            tree.Add(12);
            tree.Add(9);

            Assert.That(tree.Count.Equals(8));
            Assert.That(tree.Root.Value.Equals(5));

            Assert.That(tree.Root.Left.Value.Equals(3));
            Assert.That(tree.Root.Left.Right.Value.Equals(4));
            Assert.That(tree.Root.Left.Left.Value.Equals(2));

            Assert.That(tree.Root.Right.Value.Equals(8));
            Assert.That(tree.Root.Right.Left.Value.Equals(7));
            Assert.That(tree.Root.Right.Right.Value.Equals(12));
            Assert.That(tree.Root.Right.Right.Left.Value.Equals(9));
        }

        [Test]
        public void AddBinaryTreeStringTest()
        {
            var tree = new BinaryTreeSearch<string>();

            tree.Add("5");
                     
            tree.Add("3");
            tree.Add("4");
            tree.Add("2");
                     
            tree.Add("8");
            tree.Add("7");
            tree.Add("12");
            tree.Add("9");

            Assert.That(tree.Count.Equals(8));
            Assert.That(tree.Root.Value.Equals("5"));

            Assert.That(tree.Root.Left.Value.Equals("3"));
            Assert.That(tree.Root.Left.Right.Value.Equals("4"));
            Assert.That(tree.Root.Left.Left.Value.Equals("2"));
            Assert.That(tree.Root.Left.Left.Left.Value.Equals("12"));

            Assert.That(tree.Root.Right.Value.Equals("8"));
            Assert.That(tree.Root.Right.Left.Value.Equals("7"));
            Assert.That(tree.Root.Right.Right.Value.Equals("9"));
        }


        #endregion

        #region Test Clear method

        [Test]
        public void ClearBinaryTreeTest()
        {
            var tree = new BinaryTreeSearch<int>();

            tree.Add(5);

            tree.Add(3);

            tree.Add(8);
            tree.Add(7);

            Assert.That(tree.Count.Equals(4));
            Assert.IsNotNull(tree.Root);

            tree.Clear();

            Assert.That(tree.Count ==0);
            Assert.IsNull(tree.Root);
        }

        #endregion

        #region Test Contains method

        [Test]
        public void ContainsTest()
        {
            var tree = new BinaryTreeSearch<int>();

            tree.Add(5);

            tree.Add(3);

            tree.Add(8);
            tree.Add(7);

            Assert.That(tree.Contains(3));
            Assert.That(tree.Contains(5));
            Assert.That(tree.Contains(8));
            Assert.That(tree.Contains(7));
            Assert.That(!tree.Contains(4));
        }

        [Test]
        public void ContainsStringTest()
        {
            var tree = new BinaryTreeSearch<string>();

            tree.Add("5");

            tree.Add("3");

            tree.Add("8");
            tree.Add("7");

            Assert.That(tree.Contains("3"));
            Assert.That(tree.Contains("5"));
            Assert.That(tree.Contains("8"));
            Assert.That(tree.Contains("7"));
            Assert.That(!tree.Contains("4"));
        }

        #endregion

        #region Test ToArray method

        [Test]
        public void ToArrayTest()
        {
            var tree = new BinaryTreeSearch<int>();

            tree.Add(5);

            tree.Add(3);
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);

            tree.Add(8);
            tree.Add(7);
            tree.Add(9);
            tree.Add(5);

            var array = tree.ToArray();

            Assert.That(array[0] == 5);

            Assert.That(array[1] == 3); //left root
            Assert.That(array[2] == 2); //left
            Assert.That(array[3] == 1); //left
            Assert.That(array[4] == 4); //right

            Assert.That(array[5] == 8); // right root
            Assert.That(array[6] == 7); //left
            Assert.That(array[7] == 5); //left
            Assert.That(array[8] == 9); //right
        }

        #endregion

    }
}