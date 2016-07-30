namespace _03.Iterator.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MoveTests
    {
        private ListIterator iterator;

        [TestInitialize]
        public void InitializeIterator()
        {
            this.iterator = new ListIterator("first", "second", "third");
        }

        [TestMethod]
        public void Move_WithNextElement_ShouldMoveInternalIndexToNextElement()
        {
            this.iterator.Move();

            var expected = "second";
            var actual = iterator.GetCurrentItem();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Move_Success_ShouldReturnTrue()
        {
            bool result = this.iterator.Move();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Move_NotSuccessful_ShouldReturnFalse()
        {
            iterator.Move();
            iterator.Move();
            bool result = iterator.Move();

            Assert.IsFalse(result);
        }
    }
}