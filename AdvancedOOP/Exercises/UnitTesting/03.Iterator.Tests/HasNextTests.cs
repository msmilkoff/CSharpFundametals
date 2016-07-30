namespace _03.Iterator.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HasNextTests
    {
        private ListIterator iterator;

        [TestInitialize]
        public void InitializeIterator()
        {
            this.iterator = new ListIterator("first", "second", "third");
        }

        [TestMethod]
        public void HasNextItem_ShouldReturnTrue()
        {
            bool result = this.iterator.HasNext();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoNextItem_ShouldReturnFalse()
        {
            this.iterator.Move();
            this.iterator.Move();

            bool result = this.iterator.HasNext();

            Assert.IsFalse(result);
        }
    }
}