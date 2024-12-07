using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SpecialQueueTest
    {
        [Test]
        public void NewQueueIsEmptyTest()
        {
            var queue = new SpecialQueue<object>();

            Assert.That(queue.Count.Equals(0));
        }

        #region Test Enqueue method

        [Test]
        public void EnqueueOneObjectTest()
        {
            var queue = new SpecialQueue<int>();

            queue.Enqueue(1);

            Assert.That(queue.Count.Equals(1));
            Assert.That(queue.Contains(1));
        }

        [Test]
        public void EnqueueDifferentTypeTest()
        {
            var queue = new SpecialQueue<object>();

            queue.Enqueue("1");
            queue.Enqueue("q");
            queue.Enqueue('a');
            queue.Enqueue("123Go...");
            queue.Peek();

            Assert.That(queue.Count.Equals(4));
            Assert.That(queue.Peek().Equals("1"));
            Assert.That(queue.Contains("123Go..."));
        }

        #endregion

        #region Test Dequeue method

        [Test]
        public void DequeueTest()
        {
            var queue = new SpecialQueue<object>();

            queue.Enqueue("1");
            queue.Enqueue(1);
            queue.Enqueue('a');
            queue.Enqueue("123Go...");

            Assert.That(queue.Count.Equals(4));

            Assert.That(queue.Dequeue().Equals("1"));
            Assert.That(queue.Dequeue().Equals(1));
            Assert.That(queue.Dequeue().Equals('a'));
            Assert.That(queue.Dequeue().Equals("123Go..."));

            Assert.That(queue.Count.Equals(0));

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue(), "Queue is empty");
        }

        #endregion


        #region Test Peek method

        [Test]
        public void PeekWhenOneObjectTest()
        {
            var queue = new SpecialQueue<int>();

            queue.Enqueue(1);
            queue.Peek();

            Assert.That(queue.Peek().Equals(1));
        }

        [Test]
        public void PeekWhenSeveralObjectsTest()
        {
            var queue = new SpecialQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Peek();

            Assert.That(queue.Peek().Equals(1));
        }

        [Test]
        public void PeekAfterDequeueTest()
        {
            var queue = new SpecialQueue<object>();

            queue.Enqueue(1);
            queue.Enqueue("2");
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Peek();

            Assert.That(queue.Peek().Equals("2"));
        }

        [Test]
        public void PeekEmptyQueueTest()
        {
            var queue = new SpecialQueue<int>();

            queue.Enqueue(1);
            queue.Dequeue();

            Assert.Throws<InvalidOperationException>(() => queue.Peek(), "Queue is empty");
        }

        #endregion

        #region Test of method Contains

        [Test]
        public void MethodContainsTest()
        {
            var queue = new SpecialQueue<string>();

            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Dequeue();

            Assert.That(!queue.Contains("1"));
            Assert.That(queue.Contains("2"));
            Assert.That(queue.Contains("3"));
        }

        #endregion

        #region Test ToArray method

        [Test]
        public void MethodToArrayTest()
        {
            var queue = new SpecialQueue<string>();

            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");
            queue.Dequeue();

            var array = queue.ToArray();

            Assert.That(array.Length == 3);
            Assert.That(array[0].Equals("2"));
            Assert.That(array[1].Equals("3"));
            Assert.That(array[2].Equals("4"));
        }

        #endregion

        #region Test Clear method

        [Test]
        public void MethodClearTest()
        {
            var queue = new SpecialQueue<string>();

            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");

            queue.Clear();

            Assert.That(queue.Count == 0);
            Assert.That(!queue.Contains("1"));
            Assert.That(!queue.Contains("2"));
            Assert.That(!queue.Contains("3"));
            Assert.That(!queue.Contains("4"));
        }

        #endregion
    }
}