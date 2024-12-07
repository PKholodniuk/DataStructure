using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class DoublyLibkedListTest
    {
        [Test]
        public void NewListIsEmptyTest()
        {
            var list = new DoublyLinkedList<object>();

            Assert.That(list.Count.Equals(0));
            Assert.IsNull(list.Last);
            Assert.IsNull(list.First);
        }

        #region Test of method Add and AddFirst

        [Test]
        public void MethodAddOneNodeTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("1");

            Assert.That(list.Count.Equals(1));
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list.Last);
        }

        [Test]
        public void MethodAddLastNodeTest()
        {
            var list = new DoublyLinkedList<int>();

            list.Add(1);
            list.Add(3);
            list.Add(2);

            Assert.That(list.Count.Equals(3));
            Assert.That(list.First.Data.Equals(1));
            Assert.That(list.Last.Data.Equals(2));
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list.Last);

        }

        [Test]
        public void MethodAddFisrtTest()
        {
            var list = new DoublyLinkedList<string>();

            list.AddFirst("1");

            Assert.That(list.Count.Equals(1));
            Assert.IsNotNull(list.First);
            Assert.IsNotNull(list.Last);
        }

        [Test]
        public void MethodAddFisrt_WithSeveralNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.AddFirst("1");
            list.AddFirst("0");

            Assert.That(list.Count.Equals(3));
            Assert.That(list.First.Data.Equals("0"));
            Assert.That(list.Last.Data.Equals("2"));
            Assert.That(list.First.Next.Data.Equals("1"));
            Assert.That(list.Last.Previous.Data.Equals("1"));
        }

        #endregion

        #region Test of method Clear

        [Test]
        public void MethodClearTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.Add("4");

            list.Clear();

            Assert.That(list.Count.Equals(0));
            Assert.IsNull(list.Last);
            Assert.IsNull(list.First);
        }

        #endregion

        #region Test of method Contains

        [Test]
        public void MethodContainsTest()
        {
            var list = new DoublyLinkedList<string>();

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
            var list = new DoublyLinkedList<string>();

            list.Add("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.Add("4");

            var array = list.ToArray();

            Assert.That(array[0].Equals("3"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("1"));
            Assert.That(array[3].Equals("4"));
        }
        #endregion

        #region Test of method RemoveFirst 

        [Test]
        public void MethodRemoveFirstWhenOneNodeTest()
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(2);

            list.RemoveFirst();

            Assert.That(list.Count == 0);
            Assert.That(!list.Contains(2));

        }

        [Test]
        public void MethodRemoveFirst_WhenTwoNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.Add("4");

            list.RemoveFirst();

            Assert.That(list.Count == 1);
            Assert.IsNotNull(list.First);
            Assert.IsNull(list.Last);
            Assert.IsNotNull(list.First.Data.Equals("4"));
        }

        [Test]
        public void MethodRemoveFirst_WhenSeveralNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("3");

            list.RemoveFirst();

            Assert.That(list.Count == 3);
            Assert.IsNotNull(list.First);
            Assert.That(list.First.Data.Equals("1"));
        }

        #endregion

        #region Test of method RemoveLast

        [Test]
        public void MethodRemoveLast_WhenOneNodeTest()
        {
            var list = new DoublyLinkedList<decimal>();

            list.AddFirst(2.1m);

            list.RemoveLast();

            Assert.That(list.Count == 0);
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        [Test]
        public void MethodRemoveLast_WhenTwoNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.Add("4");

            list.RemoveLast();

            Assert.That(list.Count == 1);
            Assert.That(list.First.Data.Equals("2"));
            Assert.That(list.Last.Data.Equals("2"));
            Assert.IsNull(list.First.Next);
            Assert.IsNull(list.Last.Previous);
        }

        [Test]
        public void MethodRemoveLast_WhenSeveralNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("3");

            list.RemoveLast();

            Assert.That(list.Count == 3);
            Assert.IsNotNull(list.Last);
            Assert.That(list.Last.Data.Equals("2"));
            Assert.That(list.Last.Previous.Data.Equals("1"));
            Assert.That(list.Last.Previous.Next.Data.Equals("2"));
        }


        #endregion

        #region Test of method Remove

        [Test]
        public void MethodRemove_WhenOneNodeTest()
        {
            var list = new DoublyLinkedList<string>();

            list.AddFirst("2");

            list.Remove("2");

            Assert.That(list.Count == 0);
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
            Assert.That(!list.Contains("2"));

        }

        [Test]
        public void MethodRemove_WhenTwoNodeTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.Add("4");

            list.Remove("2");

            Assert.That(list.Count == 1);
            Assert.IsNotNull(list.First);
            Assert.IsNull(list.Last);
            Assert.IsNotNull(list.First.Data.Equals("4"));
        }

        [Test]
        public void MethodRemove_WhenSeveralNodesTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("3");

            list.Remove("2");

            Assert.That(list.Count == 3);
            Assert.That(!list.Contains("2"));
            Assert.That(list.Last.Previous.Data.Equals("1"));
            Assert.That(list.First.Next.Next.Data.Equals("3"));
        }

        [Test]
        public void MethodRemove_FromTheEndTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("3");

            list.Remove("3");

            Assert.That(list.Count == 3);
            Assert.That(!list.Contains("3"));
            Assert.That(list.Last.Data.Equals("2"));
            Assert.That(list.Last.Previous.Data.Equals("1"));
            Assert.That(list.Last.Previous.Next.Data.Equals("2"));
        }

        #endregion

        #region Test of method Insert 

        [Test]
        public void MethodInsertToTheFirstTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("3");
            list.AddFirst("2");
            list.Add("4");

            list.Insert(0, "1");

            var array = list.ToArray();

            Assert.That(array[0].Equals("1"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("3"));
            Assert.That(array[3].Equals("4"));

            Assert.That(list.First.Next.Previous.Data.Equals("1"));
        }

        [Test]
        public void MethodInsertToLastPlaceTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.AddFirst("1");
            list.Add("4");

            list.Insert(2, "3");

            var array = list.ToArray();

            Assert.That(array[0].Equals("1"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("3"));
            Assert.That(array[3].Equals("4"));

            Assert.That(list.Last.Previous.Previous.Data.Equals("2"));
            Assert.That(list.Last.Previous.Data.Equals("3"));
            Assert.That(list.Last.Data.Equals("4"));
        }

        [Test]
        public void MethodInsertToTheEndTest()
        {
            var list = new DoublyLinkedList<string>();

            list.Add("2");
            list.AddFirst("1");
            list.Add("3");

            list.Insert(3, "4");

            var array = list.ToArray();

            Assert.That(array[0].Equals("1"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("3"));
            Assert.That(array[3].Equals("4"));

            Assert.That(list.Last.Previous.Previous.Data.Equals("2"));
            Assert.That(list.Last.Previous.Data.Equals("3"));
            Assert.That(list.Last.Data.Equals("4"));
        }

        [Test]
        public void MethodInsert_InTheMiddleTest()
        {
            var list = new DoublyLinkedList<string>();

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

            Assert.That(list.Last.Previous.Previous.Data.Equals("2"));
            Assert.That(list.Last.Previous.Data.Equals("3"));
            Assert.That(list.Last.Data.Equals("4"));
        }

        #endregion
    }
}