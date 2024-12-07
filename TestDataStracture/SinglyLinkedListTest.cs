using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SinglyLinkedListTest
    {
        [Test]
        public void NewListIsEmptyTest()
        {
            var list = new SinglyLinkedList<object>();

            Assert.That(list.Count.Equals(0));
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        #region Test of method Add and AddFirst

        [Test]
        public void MethodAddAndFirstNodeTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("1");

            Assert.That(list.Count.Equals(1));
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list.Last);
        }

        [Test]
        public void MethodAddLastNodeTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("1");
            list.Add("2");

            Assert.That(list.Count.Equals(2));
            Assert.That(list.First.Data.Equals("1"));
            Assert.That(list.Last.Data.Equals("2"));
            Assert.That(list.First.Next.Data.Equals("2"));
        }

        [Test]
        public void MethodAddFisrtTest()
        {
            var list = new SinglyLinkedList<string>();

            list.AddFirst("1");

            Assert.That(list.Count.Equals(1));
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list.Last);
        }

        [Test]
        public void MethodAddFisrt_WithSeveralNodesTest()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(1);
            list.AddFirst(2);
            list.AddFirst(3);

            Assert.That(list.Count.Equals(3));
            Assert.That(list.First.Data.Equals(3));
            Assert.That(list.First.Next.Data.Equals(2));
            Assert.That(list.Last.Data.Equals(1));
        }

        #endregion

        #region Test of method Clear

        [Test]
        public void MethodClearTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.Add("4");

            list.Clear();

            Assert.That(list.Count.Equals(0));
            Assert.That(list.First == null);
            Assert.That(list.Last == null);
        }

        #endregion

        #region Test of method Contains

        [Test]
        public void MethodContainsTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.Add("4");

            Assert.That(list.Contains("2"));
            Assert.That(list.Contains("1"));
            Assert.That(list.Contains("3"));
            Assert.That(list.Contains("4"));
            Assert.That(!list.Contains("5"));
            Assert.That(!list.Contains("0"));
        }

        #endregion

        #region Test of method ToArray

        [Test]
        public void MethodToArrayTest()
        {
            var list = new SinglyLinkedList<int>();

            list.Add(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.Add(4);

            var array = list.ToArray();

            Assert.That(array[0].Equals(3));
            Assert.That(array[1].Equals(2));
            Assert.That(array[2].Equals(1));
            Assert.That(array[3].Equals(4));
        }
        #endregion

        #region Test of method Insert

        [Test]
        public void MethodInsertToZeroPlaceTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("3");
            list.AddFirst("2");
            list.Add("4");

            list.Insert(0, "1");

            var array = list.ToArray();

            Assert.That(array[0].Equals("1"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("3"));
            Assert.That(array[3].Equals("4"));
        }

        [Test]
        public void MethodInsertToLastPlaceTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("2");
            list.AddFirst("1");
            list.Add("4");

            list.Insert(2, "3");

            var array = list.ToArray();

            Assert.That(array[0].Equals("1"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("3"));
            Assert.That(array[3].Equals("4"));
        }

        [Test]
        public void MethodInsertToTheMiddleOfListTest()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("4");

            list.Insert(3, "3");

            var array = list.ToArray();

            Assert.That(array[0].Equals("0"));
            Assert.That(array[1].Equals("1"));
            Assert.That(array[2].Equals("2"));
            Assert.That(array[3].Equals("3"));
            Assert.That(array[4].Equals("4"));
        }

        #endregion
    }
}