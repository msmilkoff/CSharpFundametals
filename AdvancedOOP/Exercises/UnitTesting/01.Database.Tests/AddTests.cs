namespace _01.Database.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void Add_ShouldAddAtEndOfCollection()
        {
            var data = new Database();

            data.Add(5);
            data.Add(10);

            Assert.AreEqual(10, data.Last);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMoreThan16Items_ShouldThrow()
        {
            var data = new Database();

            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            for (int i = 0; i < items.Length; i++)
            {
                data.Add(items[i]);
            }
        }
    }
}