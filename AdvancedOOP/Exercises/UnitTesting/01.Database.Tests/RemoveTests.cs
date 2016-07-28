namespace _01.Database.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void Remove_ShouldRemoveLastElement()
        {
            var data = new Database(1, 2, 3);

            data.Remove();

            int actual = data.Last;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_FromEmptyDatabase_ShouldThrow()
        {
            var data = new Database();
            data.Remove();
        }
    }
}