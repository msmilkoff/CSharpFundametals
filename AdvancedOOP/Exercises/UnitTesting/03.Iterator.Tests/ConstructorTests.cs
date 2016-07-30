namespace _03.Iterator.Tests
{
    using System;
    using Iterator;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParameter_ShouldThrow()
        {
            // Act
            var iterator = new ListIterator("Pesho", null, "Gosho");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Empty_ShouldThrow()
        {
            var iterator = new ListIterator();
        }

        [TestMethod]
        public void Constructor_InitialInternalIndex_ShoudBeSetToZero()
        {
            var iterator = new ListIterator("one", "two", "three");

            var expected = "one";
            var actual = iterator.GetCurrentItem();

            Assert.AreEqual(expected, actual);
        }
    }
}
