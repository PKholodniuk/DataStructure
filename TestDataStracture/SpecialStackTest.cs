using DataStructureLib;

namespace TestDataStracture
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SpecialStackTest
    {
        [Test]
        public void NewStackIsEmptyTest()
        {
            var stack = new SpecialStak();

            Assert.That(stack.Count.Equals(0));
        }

        #region Test Push method

        [Test]
        public void PushOneObjectTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");

            Assert.That(stack.Count.Equals(1));
            Assert.That(stack.Contains("1"));
        }

        [Test]
        public void StackDifferentTypeTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");
            stack.Push("q");
            stack.Push('a');
            stack.Push("123Go...");
            stack.Peek();

            Assert.That(stack.Count.Equals(4));
            Assert.That(stack.Peek().Equals("123Go..."));
            Assert.That(stack.Contains("q"));
        }

        #endregion

        #region Test Pop method

        [Test]
        public void PopTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");
            stack.Push(1);
            stack.Push('a');
            stack.Push("123Go...");

            Assert.That(stack.Count.Equals(4));

            Assert.That(stack.Pop().Equals("123Go..."));
            Assert.That(stack.Pop().Equals('a'));
            Assert.That(stack.Pop().Equals(1));
            Assert.That(stack.Pop().Equals("1"));

            Assert.That(stack.Count.Equals(0));

            Assert.IsNull(stack.Pop());
        }

        #endregion


        #region Test Peek method

        [Test]
        public void PeekWhenOneObjectTest()
        {
            var stack = new SpecialStak();

            stack.Push(1);
            stack.Peek();

            Assert.That(stack.Peek().Equals(1));
        }

        [Test]
        public void PeekWhenSeveralObjectsTest()
        {
            var stack = new SpecialStak();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Peek();

            Assert.That(stack.Peek().Equals(3));
        }

        [Test]
        public void PeekAfterPopTest()
        {
            var stack = new SpecialStak();

            stack.Push(1);
            stack.Push("2");
            stack.Push("3");
            stack.Push(3);
            stack.Pop();
            stack.Peek();

            Assert.That(stack.Peek().Equals("3"));
        }

        [Test]
        public void PeekEmptyStackTest()
        {
            var stack = new SpecialStak();

            stack.Push(1);
            stack.Pop();
            stack.Peek();

            Assert.IsNull(stack.Peek());
        }

        #endregion

        #region Test of method Contains

        [Test]
        public void MethodContainsTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Pop();

            Assert.That(stack.Contains("1"));
            Assert.That(stack.Contains("2"));
            Assert.That(!stack.Contains("3"));
        }

        #endregion

        #region Test ToArray method

        [Test]
        public void MethodToArrayTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Pop();

            var array = stack.ToArray();

            Assert.That(array.Length == 3);
            Assert.That(array[0].Equals("3"));
            Assert.That(array[1].Equals("2"));
            Assert.That(array[2].Equals("1"));
        }

        #endregion

        #region Test Clear method

        [Test]
        public void MethodClearTest()
        {
            var stack = new SpecialStak();

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Pop();

            stack.Clear();

            Assert.That(stack.Count == 0);
            Assert.That(!stack.Contains("1"));
            Assert.That(!stack.Contains("2"));
            Assert.That(!stack.Contains("3"));
            Assert.That(!stack.Contains("4"));
        }

        #endregion
    }
}