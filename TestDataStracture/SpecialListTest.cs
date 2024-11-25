using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SpecialListTest
    {
        [Test]
        public void NewListIsEmptyTest()
        {
            var list = new SpecialList();

            Assert.That(list.Count.Equals(0));
        }

        #region Test of method Add

        [Test]
        public void MethodAddTest()
        {
            var list = new SpecialList();

            int itemAdded = 5;

            for (int i = 0; i < itemAdded; i++)
            {
                list.Add(i);
            }

            Assert.That(itemAdded == list.Count);
        }

        [Test]
        public void MethodAddWithExtendedInnerArrayTest()
        {
            var list = new SpecialList();

            int itemAdded = 25;

            for (int i = 0; i < itemAdded; i++)
            {
                list.Add(i);
            }

            Assert.That(itemAdded == list.Count);
        }

        [Test]
        public void MethodAddWithDifferentValuesTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            Assert.That(list.Count.Equals(3));
        }

        #endregion

        #region Test of method Insert

        [Test]
        public void MethodInsertLastIndexTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            int LastItem = list.IndexOf(2);
            int countElements = list.Count;

            list.Insert(2, "newItem");

            Assert.That(list.Count.Equals(countElements + 1));

            Assert.That(list.IndexOf(1) == 0);
            Assert.That(list.IndexOf("newItem") == 2);
            Assert.That(list.IndexOf("hello") == list.Count - 1);
        }

        [Test]
        public void MethodInsertWithExtendedInnerArrayTest()
        {
            var list = new SpecialList();

            list.Add(100);

            int itemInserted = 25;

            for (int i = 0; i < itemInserted; i++)
            {
                list.Insert(i, i);
            }

            Assert.That(list.IndexOf(100) == list.Count - 1);
            Assert.That(list.IndexOf(0) == 0);
            Assert.That(list.IndexOf(20) == 20);
            Assert.That(list.Count == itemInserted + 1);
        }

        #endregion

        #region Test of method Contains

        [Test]
        public void MethodContainsTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            Assert.That(list.Contains(1));
            Assert.That(!list.Contains(2));
            
            Assert.That(list.Contains('a'));
            Assert.That(!list.Contains('b'));

            Assert.That(list.Contains("hello"));
            Assert.That(!list.Contains("hell"));
        }

        #endregion

        #region Test of method Clear

        [Test]
        public void MethodClearTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            Assert.That(list.Count.Equals(3));

            list.Clear();

            Assert.That(list.Count.Equals(0));

            Assert.That(!list.Contains(1));
            Assert.That(!list.Contains('a'));
            Assert.That(!list.Contains("hello"));
        }
        #endregion

        #region Test of method Remove and RemoveAt

        [Test]
        public void MethodRemoveTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            list.Remove("hello");

            Assert.That(list.Count.Equals(2));

            Assert.That(list.Contains(1));
            Assert.That(list.Contains('a'));
            Assert.That(!list.Contains("hello"));
        }

        [Test]
        public void MethodRemoveAtTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            int index = list.IndexOf("hello");

            list.RemoveAt(index);

            Assert.That(list.Count.Equals(2));

            Assert.That(list.Contains(1));
            Assert.That(list.Contains('a'));
            Assert.That(!list.Contains("hello"));
        }

        #endregion

        #region Test of method ToArray

        [Test]
        public void MethodToArrayTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            var newArray = list.ToArray();

            Assert.That(list.Count == newArray.Length);
        }

        [Test]
        public void IndexerTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            Assert.That(list[0].Equals(1));
            Assert.That(list[1].Equals('a'));
            Assert.That(list[2].Equals("hello"));

            list[2] = "Ted";

            Assert.That(list[2].Equals("Ted"));
            Assert.That(!list[2].Equals("hello"));
        }

        #endregion

        #region Test of method Reverse

        [Test]
        public void MethodReverseTest()
        {
            var list = new SpecialList();

            list.Add(1);
            list.Add('a');
            list.Add("hello");

            list.Reverse();

            Assert.That(list.IndexOf(1) == list.Count-1);
            Assert.That(list.IndexOf("hello") == 0);
        }

        #endregion
    }
}